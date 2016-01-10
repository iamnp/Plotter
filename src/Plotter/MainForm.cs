using System;
using System.Linq;
using System.Windows.Forms;

namespace Plotter
{
    /// <summary>
    ///     Класс формы, содержащей основную логику приложения.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        ///     Группа кнопок построения графика функции.
        /// </summary>
        private readonly ObjectGroup _drawFuncButtons;

        /// <summary>
        ///     Группа кнопок построения графика интеграла функции.
        /// </summary>
        private readonly ObjectGroup _drawIntegralButtons;

        /// <summary>
        ///     Группа полей ввода параметров.
        /// </summary>
        private readonly ObjectGroup _paramInputs;

        /// <summary>
        ///     Группа пунктов выбора темы.
        /// </summary>
        private readonly ObjectGroup _themeItems;

        /// <summary>
        ///     Экземпляр функции варианта 26.
        /// </summary>
        private MyFunction _myFunction;

        /// <summary>
        ///     Предыдущее значение скорости анимации.
        /// </summary>
        private double _prevDxPerSec = double.NaN;

        /// <summary>
        ///     Класс формы, содержащей основную логику приложения.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            // Инициализируем групповые объекты.
            _paramInputs = new ObjectGroup(xMinInputBox, xMaxInputBox, dxInputBox, yTrackBar.OriginalTrackBar,
                zTrackBar.OriginalTrackBar);
            _drawFuncButtons = new ObjectGroup(plotFuncButton, plotFuncMenuItem, plotFuncToolItem);
            _drawIntegralButtons = new ObjectGroup(plotIntegralButton, plotIntegralMenuItem, plotIntegralToolItem);
            _drawIntegralButtons.SetProperty("Enabled", false);
            _drawIntegralButtons.SetProperty("Text", "Построить график интеграла с анимацией");
            _themeItems = new ObjectGroup(defaultThemeMenuItem, minimalThemeMenuItem, businessThemeMenuItem,
                marketingThemeMenuItem, monochromeThemeMenuItem);

            new ObjectGroup(yTrackBar.OriginalTrackBar, zTrackBar.OriginalTrackBar)
                .AddEventHandler("ValueChanged",
                    new EventHandler((o, e) => _drawIntegralButtons.SetProperty("Enabled", false)));
            new ObjectGroup(xMinInputBox, xMaxInputBox, dxInputBox)
                .AddEventHandler("TextChanged",
                    new EventHandler((o, e) => _drawIntegralButtons.SetProperty("Enabled", false)));

            plotterControl1.Settings.SmoothDrawing = smoothCheckBox.Checked;
            plotterControl1.MouseWheel += PlotterControl1_MouseWheel;
            plotterControl1.Cursor = Cursors.Cross;

            ActiveControl = plotFuncButton;
            plotterControl1.Focus();
            Load += (sender, args) => plotFuncButton.PerformClick();
        }

        /// <summary>
        ///     Обработчик нажатия кнопки построения графика функции.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void plotFuncButton_Click(object sender, EventArgs e)
        {
            // Проверяем вводимые данные на корректность.
            if (!xMinInputBox.DoubleValueAvailable)
            {
                xMinInputBox.Focus();
                xMinInputBox.SelectAll();
                return;
            }
            if (!xMaxInputBox.DoubleValueAvailable)
            {
                xMaxInputBox.Focus();
                xMaxInputBox.SelectAll();
                return;
            }
            if (!dxInputBox.DoubleValueAvailable)
            {
                dxInputBox.Focus();
                dxInputBox.SelectAll();
                return;
            }
            if (xMinInputBox.DoubleValue > xMaxInputBox.DoubleValue)
            {
                MessageBox.Show("Xmax должно быть меньше или равно Xmin", "Ошибка", MessageBoxButtons.OK);
                return;
            }
            if (dxInputBox.DoubleValue <= 0.0)
            {
                MessageBox.Show("∆x должно быть больше 0", "Ошибка", MessageBoxButtons.OK);
                return;
            }

            // Устанавливаем граничные значения для оси X.
            plotterControl1.Settings.StartX = xMinInputBox.DoubleValue;
            plotterControl1.Settings.StopX = xMaxInputBox.DoubleValue;

            _myFunction = new MyFunction
            {
                Y = yTrackBar.Value,
                Z = zTrackBar.Value
            };

            var points = _myFunction.Evaluate(xMinInputBox.DoubleValue, xMaxInputBox.DoubleValue,
                dxInputBox.DoubleValue);

            // Устанавливаем граничные знчения для оси Y.
            var maxY = 1.0;
            var minY = -1.0;
            if (points != null)
            {
                maxY = points.Max(p => p.Max(k => k.Y));
                minY = points.Min(p => p.Min(k => k.Y));
            }
            var d = (maxY - minY)/10;
            if (Math.Abs(maxY - minY) < 1e-9) d = 1;
            plotterControl1.Settings.StopY = maxY + d;
            plotterControl1.Settings.StartY = minY - d;

            // Добавляем задание для отрисовки нашей функции.
            plotterControl1.Tasks.Clear();
            plotterControl1.Tasks.Add(new PlotterControl.PlotTask {Points = points, Legend = "F(x)"});
            if (oneToOneYScaleRadioButton.Checked)
                plotterControl1.Settings.ScaleY = plotterControl1.CalculateOneToOneScaleY();
            plotterControl1.Redraw();
            _drawIntegralButtons.SetProperty("Enabled", true);
        }

        /// <summary>
        ///     Обработчик нажатия кнопки построения графика интеграла функции.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void plotIntegralButton_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                // График в процессе построения, поэтому ставим процесс на паузу.
                StopDrawingIntegral();
            }
            else
            {
                // График в данный момент не строится, поэтому начинаем его построение.
                _prevDxPerSec = double.NaN;

                // Если задание для пост роения графика интеграла еще не добавлено, то добавляем его.
                if (plotterControl1.Tasks.Count == 1)
                {
                    plotterControl1.Tasks.Add(new PlotterControl.PlotTask
                    {
                        Points = _myFunction.EvaluateIntegral(xMinInputBox.DoubleValue, xMaxInputBox.DoubleValue,
                            dxInputBox.DoubleValue),
                        Legend = "I(x)",
                        DrawPart = 0.0
                    });
                }

                // Если график уже полностью построен, то начнинаем строить опять с начала.
                if (plotterControl1.Tasks[1].DrawPart >= 1.0)
                    plotterControl1.Tasks[1].DrawPart = 0.0;
                StartDrawingIntegral();
            }
        }

        /// <summary>
        ///     Обработчик переключения значения сглаживания.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void smoothCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Определяем объект, через который произошло изменение параметра.
            var check = sender is CheckBox
                ? smoothCheckBox.Checked
                : (sender is ToolStripMenuItem ? smoothMenuItem.Checked : smoothToolItem.Checked);

            smoothCheckBox.Checked = smoothToolItem.Checked = smoothMenuItem.Checked = check;
            plotterControl1.Settings.SmoothDrawing = check;
            plotterControl1.Redraw();
        }

        /// <summary>
        ///     Обработчик срабатывания таймера, шаг отрисовки графика интеграла.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            // Если значение скорости отрисовки не задано, то выводим соответствующее сообщение.
            if (double.IsNaN(_prevDxPerSec))
            {
                if (!dxPerSecInputBox.DoubleValueAvailable)
                {
                    StopDrawingIntegral();
                    dxPerSecInputBox.Focus();
                    dxPerSecInputBox.SelectAll();
                    return;
                }

                if (dxPerSecInputBox.DoubleValue <= 0.0)
                {
                    StopDrawingIntegral();
                    MessageBox.Show("∆x / sec должно быть > 0", "Ошибка", MessageBoxButtons.OK);
                    return;
                }
            }

            // Устанавливаем текущее значение скорости отрисовки.
            if (dxPerSecInputBox.DoubleValueAvailable && dxPerSecInputBox.DoubleValue > 0)
                _prevDxPerSec = dxPerSecInputBox.DoubleValue;

            // Шаг анимации.
            var p = _prevDxPerSec/20.0/
                    (plotterControl1.Settings.StopX - plotterControl1.Settings.StartX);
            plotterControl1.Tasks[1].DrawPart += p;

            // Если график интеграла отрисован полностью, то ставим процесс на паузу.
            if (plotterControl1.Tasks[1].DrawPart >= 1.0)
            {
                plotterControl1.Tasks[1].DrawPart = 1.0;
                StopDrawingIntegral();
            }

            // Перерисовываем график.
            plotterControl1.Redraw();
        }

        /// <summary>
        ///     Показ окна «О программе».
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutMenuItem_Click(object sender, EventArgs e)
        {
            var f = new AboutForm();
            f.ShowDialog(this);
            f.Dispose();
        }

        /// <summary>
        ///     Ставит отрисовку интеграла на паузу.
        /// </summary>
        private void StopDrawingIntegral()
        {
            _drawIntegralButtons.SetProperty("Text", "Построить график интеграла с анимацией");
            _drawFuncButtons.SetProperty("Enabled", true);
            timer1.Enabled = false;
            _paramInputs.SetProperty("Enabled", true);
        }

        /// <summary>
        ///     Запускает отрисовку интеграла.
        /// </summary>
        private void StartDrawingIntegral()
        {
            _drawIntegralButtons.SetProperty("Text", "Остановить построение графика интеграла");
            _drawFuncButtons.SetProperty("Enabled", false);
            timer1.Enabled = true;
            _paramInputs.SetProperty("Enabled", false);
        }

        /// <summary>
        ///     Обработчик события изменения положения переключателя автоматического выбора масштаба по оси Y.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void autoYScaleRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (!autoYScaleRadioButton.Checked) return;
            plotterControl1.Settings.ScaleY = 1.0;
            plotterControl1.Redraw();
        }

        /// <summary>
        ///     Обработчик события изменения положения переключателя выбора масштаба один к одному по оси Y.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void oneToOneYScaleRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (!oneToOneYScaleRadioButton.Checked) return;
            plotterControl1.Settings.ScaleY = plotterControl1.CalculateOneToOneScaleY();
            plotterControl1.Redraw();
        }

        /// <summary>
        ///     Обработчик события прокрутки колеса мышки над графиком.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlotterControl1_MouseWheel(object sender, MouseEventArgs e)
        {
            autoYScaleRadioButton.Checked = oneToOneYScaleRadioButton.Checked = false;
            plotterControl1.Settings.ScaleY *= 1 + Math.Sign(e.Delta)*0.1;
            if (plotterControl1.Settings.ScaleY < 1e-4)
                plotterControl1.Settings.ScaleY = 1e-4;
            if (plotterControl1.Settings.ScaleY > 1e4)
                plotterControl1.Settings.ScaleY = 1e4;
            plotterControl1.Redraw();
        }

        /// <summary>
        ///     Фокусируем компонент графика если курсор находится над ним.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void plotterControl1_MouseEnter(object sender, EventArgs e)
        {
            plotterControl1.Focus();
        }

        /// <summary>
        ///     Обработчик события изменения темы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void themeChanged_Click(object sender, EventArgs e)
        {
            var item = sender as ToolStripMenuItem;
            if (item != null)
            {
                _themeItems.SetProperty("Checked", false);
                item.Checked = true;
                if (item == defaultThemeMenuItem)
                    plotterControl1.Theme = PlotterControl.PlotterTheme.Default;
                if (item == minimalThemeMenuItem)
                    plotterControl1.Theme = PlotterControl.PlotterTheme.Minimal;
                if (item == businessThemeMenuItem)
                    plotterControl1.Theme = PlotterControl.PlotterTheme.Business;
                if (item == marketingThemeMenuItem)
                    plotterControl1.Theme = PlotterControl.PlotterTheme.Marketing;
                if (item == monochromeThemeMenuItem)
                    plotterControl1.Theme = PlotterControl.PlotterTheme.Monochrome;
                plotterControl1.Redraw();
            }
        }

        /// <summary>
        ///     Обработчик события изменения размеров формы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (oneToOneYScaleRadioButton.Checked)
            {
                oneToOneYScaleRadioButton_CheckedChanged(oneToOneYScaleRadioButton, EventArgs.Empty);
            }
        }
    }
}