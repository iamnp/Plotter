using System;

namespace Plotter
{
    /// <summary>
    ///     Класс для представления функции из варианта 26.
    /// </summary>
    public class MyFunction : Function
    {
        /// <summary>
        ///     Аргумент функции.
        /// </summary>
        public double X;

        /// <summary>
        ///     Параметр функции y.
        /// </summary>
        public double Y;

        /// <summary>
        ///     Параметр функции z.
        /// </summary>
        public double Z;

        /// <summary>
        ///     Вычисляет значение функции в точке x.
        /// </summary>
        /// <param name="x">Аргумент функции.</param>
        /// <returns>Значение функции в точке x, или double.NaN, если в точке x функция не определена.</returns>
        public override double this[double x]
        {
            get
            {
                X = x;
                double v;
                try
                {
                    v = Math.Pow(Y, Math.Pow(Math.Abs(X), 1.0/3.0)) +
                        Math.Pow(Math.Cos(Y), 3)*
                        (Math.Abs(X - Y)*(1.0 + Math.Pow(Math.Sin(Z), 2)/Math.Sqrt(X + Y))/
                         (Math.Pow(Math.E, Math.Abs(X - Y)) + X/2.0));
                }
                catch
                {
                    v = double.NaN;
                }

                return v;
            }
        }
    }
}