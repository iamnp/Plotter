using System;
using System.Windows.Forms;

namespace Plotter
{
    internal static class Program
    {
        /// <summary>
        ///     Точка входа в программу.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}