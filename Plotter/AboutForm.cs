using System;
using System.Windows.Forms;

namespace Plotter
{
    /// <summary>
    ///     Класс формы с информацией о программе.
    /// </summary>
    public partial class AboutForm : Form
    {
        /// <summary>
        ///     Инициализирует компоненты.
        /// </summary>
        public AboutForm()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     Обработчик события нажатия кнопки «Ок», закрывает форму.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void okButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}