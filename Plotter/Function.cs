using System.Collections.Generic;
using System.Drawing;

namespace Plotter
{
    /// <summary>
    ///     Класс для представления математической функции одного аргумента.
    /// </summary>
    public abstract class Function
    {
        /// <summary>
        ///     Вычисляет значение функции в точке x.
        /// </summary>
        /// <param name="x">Аргумент функции.</param>
        /// <returns>Значение функции в точке x, или double.NaN, если в точке x функция не определена.</returns>
        public abstract double this[double x] { get; }

        /// <summary>
        ///     Проверяет значение типа double на пригодность к построению на графике.
        /// </summary>
        /// <param name="d">Значение для проверки.</param>
        /// <returns>True, если значение пригодно для построения, иначе - false.</returns>
        public bool IsValidDoubleValue(double d)
        {
            return !double.IsNaN(d) && !double.IsInfinity(d);
        }

        /// <summary>
        ///     Вычисляет значения функции в точках от xmin до xmax с шагом dx.
        /// </summary>
        /// <param name="xmin">Начальное значение аргумента.</param>
        /// <param name="xmax">Конечное значение аргумента.</param>
        /// <param name="dx">Шаг изменения аргумента.</param>
        /// <returns>Массив отрезков, на которых функция определена.</returns>
        public PointF[][] Evaluate(double xmin, double xmax, double dx)
        {
            // Список отрезков, на которых функция определена.
            var list = new List<List<PointF>>();
            // Текущий отрезок для добавления точек
            var current = new List<PointF>();

            var steps = (int) ((xmax - xmin)/dx);
            var x = xmin;
            for (var i = 0; i <= steps; ++i)
            {
                var v = this[x];

                if (IsValidDoubleValue(v))
                {
                    // Если значение функции в точке x пригодно для построения, то добавляем точку к текущему отрезку. 
                    current.Add(new PointF((float) x, (float) v));
                }
                else
                {
                    // Иначе непустой отрезок добавляем к списку отрезков для построения.
                    if (current.Count != 0)
                    {
                        list.Add(current);
                        current = new List<PointF>();
                    }
                }
                x += dx;
            }
            if (current.Count != 0)
            {
                list.Add(current);
            }

            if (list.Count == 0) return null;

            // Конвертируем списки в массивы.
            var arr = new PointF[list.Count][];
            for (var i = 0; i < list.Count; ++i)
            {
                arr[i] = list[i].ToArray();
            }

            return arr;
        }

        /// <summary>
        ///     Вычисляет значения определенного интеграла функции в точках от xmin до xmax с шагом dx.
        /// </summary>
        /// <param name="xmin">Начальное значение аргумента.</param>
        /// <param name="xmax">Конечное значение аргумента.</param>
        /// <param name="dx">Шаг изменения аргумента.</param>
        /// <returns>Массив отрезков, на которых определен интеграл функции.</returns>
        public PointF[][] EvaluateIntegral(double xmin, double xmax, double dx)
        {
            // Отрезок для построения 
            var current = new List<PointF>();

            var sum = 0.0;
            var steps = (int) ((xmax - xmin)/dx);
            var x = xmin;
            for (var i = 0; i <= steps; ++i)
            {
                var v = this[x];
                // Если значение функции в точке x пригодно для построения, то прибавляем часть к площади,
                // иначе считаем площадь равной нулю.
                sum += (!IsValidDoubleValue(v) ? 0.0 : v)*dx;
                current.Add(new PointF((float) x, (float) sum));
                x += dx;
            }

            if (current.Count == 0) return null;

            return new[] {current.ToArray()};
        }
    }
}