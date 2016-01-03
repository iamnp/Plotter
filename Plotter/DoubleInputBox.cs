using System;
using System.Drawing;
using System.Windows.Forms;

namespace Plotter
{
    /// <summary>
    ///     Класс компонента для ввода чисел типа double с подсветкой и всплывающим сообщением о неверном вводе.
    /// </summary>
    public class DoubleInputBox : TextBox
    {
        /// <summary>
        ///     Сообщение о неверном вводе.
        /// </summary>
        private const string Msg = "В это поле нужно ввести число";

        /// <summary>
        ///     Зеленый цвет.
        /// </summary>
        private readonly Color _green = Color.FromArgb(255, 190, 255, 190);

        /// <summary>
        ///     Красный цвет.
        /// </summary>
        private readonly Color _red = Color.FromArgb(255, 255, 190, 190);

        /// <summary>
        ///     Компонент для показа всплывающего текста.
        /// </summary>
        private readonly ToolTip _toolTip = new ToolTip();

        /// <summary>
        ///     Инициализирует компоненты.
        /// </summary>
        public DoubleInputBox()
        {
            TextChanged += OnTextChanged;
            DoubleValue = double.NaN;
            GotFocus += OnGotFocus;
            LostFocus += OnLostFocus;
        }

        /// <summary>
        ///     True, если пользователь ввел значение типа double, иначе - false.
        /// </summary>
        public bool DoubleValueAvailable
        {
            get { return !double.IsNaN(DoubleValue); }
        }

        /// <summary>
        ///     Введенное пользователем значение типа double.
        /// </summary>
        public double DoubleValue { get; private set; }

        private void OnLostFocus(object sender, EventArgs eventArgs)
        {
            if (!DoubleValueAvailable)
            {
                _toolTip.RemoveAll();
            }
        }

        /// <summary>
        ///     Обработчик события потери фокуса компонентом.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private void OnGotFocus(object sender, EventArgs eventArgs)
        {
            if (!DoubleValueAvailable)
            {
                _toolTip.Show(Msg, this, 10, Height);
            }
        }

        /// <summary>
        ///     Обработчик события получения фокуса компонентом.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private void OnTextChanged(object sender, EventArgs eventArgs)
        {
            double a;
            if (double.TryParse(Text.Replace('.', ','), out a))
            {
                DoubleValue = a;
                _toolTip.RemoveAll();
                BackColor = _green;
            }
            else
            {
                DoubleValue = double.NaN;
                _toolTip.Show(Msg, this, 10, Height);
                BackColor = _red;
            }
        }
    }
}