using System;
using System.Globalization;
using System.Windows.Forms;

namespace Plotter
{
    /// <summary>
    ///     Класс компонента-ползунка для выбора дробных значений с отображением текущего значения.
    /// </summary>
    public partial class MyTrackBar : UserControl
    {
        /// <summary>
        ///     Инициализирует компоненты.
        /// </summary>
        public MyTrackBar()
        {
            InitializeComponent();
            Divisor = 1.0;
            OriginalTrackBar.ValueChanged += TrackBarOnValueChanged;
            valueLabel.Text = Value.ToString(CultureInfo.CurrentCulture);
        }

        /// <summary>
        ///     Делитель для представления дробных значений.
        /// </summary>
        public double Divisor { get; set; }

        /// <summary>
        ///     Исходный компонент TrackBar.
        /// </summary>
        public TrackBar OriginalTrackBar
        {
            get { return trackBar; }
        }

        /// <summary>
        ///     Максималное значение.
        /// </summary>
        public int Maximum
        {
            get { return OriginalTrackBar.Maximum; }
            set
            {
                maximumLabel.Text = (value/Divisor).ToString(CultureInfo.CurrentCulture);
                OriginalTrackBar.Maximum = value;
            }
        }

        /// <summary>
        ///     Минимальное значение.
        /// </summary>
        public int Minimum
        {
            get { return OriginalTrackBar.Minimum; }
            set
            {
                minimumLabel.Text = (value/Divisor).ToString(CultureInfo.CurrentCulture);
                OriginalTrackBar.Minimum = value;
            }
        }

        /// <summary>
        ///     Выбранное значение.
        /// </summary>
        public double Value
        {
            get { return OriginalTrackBar.Value/Divisor; }
            set { OriginalTrackBar.Value = (int) (value*Divisor); }
        }

        /// <summary>
        ///     Обработчик события изменения положения ползунка.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private void TrackBarOnValueChanged(object sender, EventArgs eventArgs)
        {
            valueLabel.Text = Value.ToString(CultureInfo.CurrentCulture);
        }
    }
}