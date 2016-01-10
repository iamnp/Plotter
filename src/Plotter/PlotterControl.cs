using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace Plotter
{
    /// <summary>
    ///     Класс компонента для построения графиков.
    /// </summary>
    public class PlotterControl : PictureBox
    {
        /// <summary>
        ///     Отступ слева.
        /// </summary>
        private const float LeftMargin = 40;

        /// <summary>
        ///     Отступ справа.
        /// </summary>
        private const float RightMargin = 150;

        /// <summary>
        ///     Отступ сверху.
        /// </summary>
        private const float TopMargin = 10;

        /// <summary>
        ///     Отступ снизу.
        /// </summary>
        private const float BottomMargin = 20;

        /// <summary>
        ///     Количество делений по оси X.
        /// </summary>
        private const int Xlabels = 10;

        /// <summary>
        ///     Количество делений по оси Y.
        /// </summary>
        private const int Ylabels = 10;

        /// <summary>
        ///     Задачи построения.
        /// </summary>
        public List<PlotTask> Tasks = new List<PlotTask>();

        /// <summary>
        ///     Текущая тема.
        /// </summary>
        public PlotterTheme Theme = PlotterTheme.Default;

        /// <summary>
        ///     Положение курсора.
        /// </summary>
        private Point _mousePos = new Point(-1, -1);

        /// <summary>
        ///     Добавляет обработчики событий.
        /// </summary>
        public PlotterControl()
        {
            Settings = new PlotterSettings();
            Resize += (o, e) => Invalidate();
            Paint += OnPaint;
            MouseMove += (sender, args) =>
            {
                if (args.X < LeftMargin || args.X > Width - RightMargin || args.Y < TopMargin || args.Y > Height - BottomMargin)
                    _mousePos = new Point(-1, -1);
                else _mousePos = new Point(args.X, args.Y);
                Redraw();
            };
        }

        /// <summary>
        ///     Настройки графопостроителя.
        /// </summary>
        public PlotterSettings Settings { get; private set; }

        /// <summary>
        ///     Перерисовывает графики.
        /// </summary>
        public void Redraw()
        {
            Invalidate();
        }

        /// <summary>
        ///     Вычисляет значение коэффициента масштаба один к одному для оси Y.
        /// </summary>
        /// <returns></returns>
        public double CalculateOneToOneScaleY()
        {
            var xValDelta = Settings.StopX - Settings.StartX;
            if (Math.Abs(xValDelta) < 1e-8) return 1.0;
            var yValDelta = Settings.StopY - Settings.StartY;
            if (Math.Abs(yValDelta) < 1e-8) return 1.0;
            var scale = (yValDelta / xValDelta) * ((Width - LeftMargin - RightMargin) / (Height - TopMargin - BottomMargin));
            if (double.IsNaN(scale)) return 1.0;
            return scale;
        }

        /// <summary>
        ///     Рисует надписи осей.
        /// </summary>
        /// <param name="g"></param>
        private void DrawAxesLabels(Graphics g)
        {
            var yAxisPos = YAxisPos();
            var xAxisPos = XAxisPos();

            var font = new Font("Arial", 10);
            var brush = new SolidBrush(Theme.AxesLabelsColor);
            g.DrawString("X", font, brush, Width - RightMargin - 12,
                xAxisPos + 3);
            g.DrawString("Y", font, brush, yAxisPos - 15, TopMargin);
        }

        /// <summary>
        ///     Рисует координатную сетку.
        /// </summary>
        /// <param name="g"></param>
        private void DrawCells(Graphics g)
        {
            var yAxisPos = YAxisPos();
            var xAxisPos = XAxisPos();

            var dx = (Width - LeftMargin - RightMargin) / Xlabels;
            var currentX = yAxisPos;
            while (currentX < Width - RightMargin - 5)
            {
                g.DrawLine(Theme.VerticalCellsPen, currentX, TopMargin, currentX, Height - BottomMargin);
                currentX += dx;
            }
            currentX = yAxisPos - dx;
            while (currentX > LeftMargin + 5)
            {
                g.DrawLine(Theme.VerticalCellsPen, currentX, TopMargin, currentX, Height - BottomMargin);
                currentX -= dx;
            }

            var dy = (Height - TopMargin - BottomMargin) / Ylabels;
            var currentY = xAxisPos;
            while (currentY < Height - BottomMargin - 5)
            {
                g.DrawLine(Theme.HorizontalCellsPen, LeftMargin, currentY, Width - LeftMargin, currentY);
                currentY += dy;
            }
            currentY = xAxisPos - dy;
            while (currentY > TopMargin + 5)
            {
                g.DrawLine(Theme.HorizontalCellsPen, LeftMargin, currentY, Width - LeftMargin, currentY);
                currentY -= dy;
            }
        }

        /// <summary>
        ///     Рисует штрихи при осях.
        /// </summary>
        /// <param name="g"></param>
        private void DrawCellDashes(Graphics g)
        {
            var yAxisPos = YAxisPos();
            var xAxisPos = XAxisPos();

            var dx = (Width - LeftMargin - RightMargin) / Xlabels;
            var currentX = yAxisPos;
            while (currentX < Width - RightMargin - 5)
            {
                g.DrawLine(Theme.VerticalDashesPen, currentX, xAxisPos - 4, currentX, xAxisPos);
                currentX += dx;
            }
            currentX = yAxisPos - dx;
            while (currentX > LeftMargin + 5)
            {
                g.DrawLine(Theme.VerticalDashesPen, currentX, xAxisPos - 4, currentX, xAxisPos);
                currentX -= dx;
            }

            var dy = (Height - TopMargin - BottomMargin) / Ylabels;
            var currentY = xAxisPos;
            while (currentY < Height - BottomMargin - 5)
            {
                g.DrawLine(Theme.HorizontalDashesPen, yAxisPos, currentY, yAxisPos + 4, currentY);
                currentY += dy;
            }
            currentY = xAxisPos - dy;
            while (currentY > TopMargin + 5)
            {
                g.DrawLine(Theme.HorizontalDashesPen, yAxisPos, currentY, yAxisPos + 4, currentY);
                currentY -= dy;
            }
        }

        /// <summary>
        ///     Оцифровывает оси.
        /// </summary>
        /// <param name="g"></param>
        private void DrawCellLabels(Graphics g)
        {
            var yAxisPos = YAxisPos();
            var xAxisPos = XAxisPos();
            var xValDelta = Settings.StopX - Settings.StartX;
            var yValDelta = Settings.StopY - Settings.StartY;

            var font = new Font("Arial", 7);
            var brush = new SolidBrush(Theme.CellsLabelsColor);

            var dx = (Width - LeftMargin - RightMargin) / Xlabels;
            var currentX = yAxisPos;
            while (currentX < Width - RightMargin - 15)
            {
                var v = Settings.StartX + xValDelta * ((currentX - LeftMargin) / (Width - LeftMargin - RightMargin));
                g.DrawString(v.ToString("F2"), font, brush, currentX - 3, xAxisPos + 2);
                currentX += dx;
            }
            currentX = yAxisPos - dx;
            while (currentX > LeftMargin + 5)
            {
                var v = Settings.StartX + xValDelta * ((currentX - LeftMargin) / (Width - LeftMargin - RightMargin));
                g.DrawString(v.ToString("F2"), font, brush, currentX - 3, xAxisPos + 2);
                currentX -= dx;
            }

            var dy = (Height - TopMargin - BottomMargin) / Ylabels;
            var currentY = xAxisPos;
            while (currentY < Height - BottomMargin + 5)
            {
                var s = RawYPosToScaledValue(currentY).ToString("F2");
                var len = g.MeasureString(s, font).Width;
                g.DrawString(s, font, brush, yAxisPos - len, currentY - 5);
                currentY += dy;
            }
            currentY = xAxisPos - dy;
            while (currentY > TopMargin + 15)
            {
                var s = RawYPosToScaledValue(currentY).ToString("F2");
                var len = g.MeasureString(s, font).Width;
                g.DrawString(s, font, brush, yAxisPos - len, currentY - 5);
                currentY -= dy;
            }
        }

        /// <summary>
        ///     Рисует оси.
        /// </summary>
        /// <param name="g"></param>
        private void DrawAxes(Graphics g)
        {
            var yAxisPos = YAxisPos();
            var xAxisPos = XAxisPos();

            g.DrawLine(Theme.YAxisPen, yAxisPos, TopMargin, yAxisPos, Height - BottomMargin);
            g.DrawLine(Theme.XAxisPen, LeftMargin, xAxisPos, Width - RightMargin, xAxisPos);
        }

        /// <summary>
        ///     Вычисляет значение точки Y по координате на графике.
        /// </summary>
        /// <param name="y"></param>
        /// <returns></returns>
        private double RawYPosToScaledValue(double y)
        {
            var yValDelta = Settings.StopY - Settings.StartY;
            double scalingLine = Settings.StartY + (Settings.StopY - Settings.StartY) / 2.0;
            var currentYFraction = (Height - y - BottomMargin) / (Height - TopMargin - BottomMargin);
            var v = scalingLine + (currentYFraction - 0.5) * yValDelta / Settings.ScaleY;
            return v;
        }

        /// <summary>
        ///     Вычисляет значение точки X по координате на графике.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        private double RawXPosToScaledValue(double x)
        {
            var xValDelta = Settings.StopX - Settings.StartX;
            var currentXFraction = (x - LeftMargin) / (Width - LeftMargin - RightMargin);
            var v = Settings.StartX + xValDelta * currentXFraction;
            return v;
        }

        /// <summary>
        ///     Вычисляет положение оси Y на графике.
        /// </summary>
        /// <returns></returns>
        private float YAxisPos()
        {
            var xValDelta = Settings.StopX - Settings.StartX;
            float yAxisPos;
            if (Math.Abs(xValDelta) < 1e-8) yAxisPos = LeftMargin + (Width - LeftMargin - RightMargin) / 2;
            else yAxisPos = (float)(LeftMargin + (Width - LeftMargin - RightMargin) * (-Settings.StartX / xValDelta));
            if (yAxisPos < LeftMargin) yAxisPos = LeftMargin;
            if (yAxisPos > Width - RightMargin) yAxisPos = Width - RightMargin;
            return yAxisPos;
        }

        /// <summary>
        ///     Вычисляет положение оси X на графике.
        /// </summary>
        /// <returns></returns>
        private float XAxisPos()
        {
            var yValDelta = Settings.StopY - Settings.StartY;
            float xAxisPos;
            if (Math.Abs(yValDelta) < 1e-8) xAxisPos = TopMargin + (Height - TopMargin - BottomMargin) / 2;
            else
                xAxisPos =
                    (float)
                        (Height -
                         (BottomMargin +
                          (Height - TopMargin - BottomMargin) * ((ScaleYPoint(0) - Settings.StartY) / yValDelta)));
            if (xAxisPos < TopMargin) xAxisPos = TopMargin;
            if (xAxisPos > Height - BottomMargin) xAxisPos = Height - BottomMargin;
            return xAxisPos;
        }

        /// <summary>
        ///     Масштабирует Y-координату графика.
        /// </summary>
        /// <param name="y"></param>
        /// <returns></returns>
        private double ScaleYPoint(double y)
        {
            double scalingLine = Settings.StartY + (Settings.StopY - Settings.StartY) / 2.0;
            return scalingLine + (y - scalingLine) * Settings.ScaleY;
        }

        /// <summary>
        ///     Рисует стрелки у осей.
        /// </summary>
        /// <param name="g"></param>
        private void DrawAxesArrows(Graphics g)
        {
            var yAxisPos = YAxisPos();
            var xAxisPos = XAxisPos();

            var xBrush = new SolidBrush(Theme.AxesArrowsColor);
            var yBrush = new SolidBrush(Theme.AxesArrowsColor);
            g.FillPolygon(xBrush, new[]
            {
                new PointF(Width - RightMargin, xAxisPos),
                new PointF(Width - RightMargin - 8, xAxisPos - 4),
                new PointF(Width - RightMargin - 8, xAxisPos + 4)
            });

            g.FillPolygon(yBrush, new[]
            {
                new PointF(yAxisPos, TopMargin),
                new PointF(yAxisPos - 4, TopMargin + 8),
                new PointF(yAxisPos + 4, TopMargin + 8)
            });
        }

        /// <summary>
        ///     Строит график.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="task">Задание для отрисовки.</param>
        /// <param name="taskIndex">Порядковый номер объекта task среди всех объектов для отрисовки.</param>
        private void Plot(Graphics g, PlotTask task, int taskIndex)
        {
            if (task.Points == null) return;
            var xValDelta = Settings.StopX - Settings.StartX;
            var yValDelta = Settings.StopY - Settings.StartY;

            var totalLen = task.Points.Sum(t => t.Length);

            if (totalLen == 0) return;

            var pointCount = (int)(totalLen * task.DrawPart);
            if (task.DrawPart > 1.0)
                pointCount = task.Points.Length;
            if (task.DrawPart < 0.0)
                pointCount = 0;
            var pointsDrawn = 0;

            var taskPen = Theme.PlotPens[taskIndex % Theme.PlotPens.Length];
            var taskBrush = new SolidBrush(taskPen.Color);

            for (var j = 0; j < task.Points.Length && pointsDrawn < pointCount; ++j)
            {
                var tmp = new List<PointF>();
                for (var i = 0; i < task.Points[j].Length && pointsDrawn < pointCount; ++i)
                {
                    var tt = new PointF((float)(LeftMargin + (task.Points[j][i].X - Settings.StartX) / xValDelta
                                                 * (Width - LeftMargin - RightMargin)),
                        (float)
                            (Height - (BottomMargin + (ScaleYPoint(task.Points[j][i].Y) - Settings.StartY) / yValDelta
                                       * (Height - TopMargin - BottomMargin))));
                    if (task.Points[j].Length == 1)
                    {
                        g.FillEllipse(taskBrush, tt.X - 3, tt.Y - 3, 6, 6);
                    }
                    else
                    {
                        tmp.Add(tt);
                    }
                    pointsDrawn += 1;
                }

                if (tmp.Count > 1)
                {
                    g.DrawLines(taskPen, tmp.ToArray());
                }
            }
        }

        /// <summary>
        ///     Рисует легенду для графика.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="task"></param>
        /// <param name="taskIndex">Порядковый номер объекта task среди всех объектов для отрисовки.</param>
        /// <param name="taskCount">Количество объектов task для отрисовки.</param>
        private void DrawLegend(Graphics g, PlotTask task, int taskIndex, int taskCount)
        {
            var font = new Font("Arial", 14);
            var brush = new SolidBrush(Theme.LegendTextColor);
            var mid = taskCount / 2.0;
            var labelYPos = (int)(TopMargin + (Height - TopMargin - BottomMargin) / 2 + (taskIndex - mid + 0.5) * 50);
            g.DrawLine(Theme.PlotPens[taskIndex % Theme.PlotPens.Length], Width - RightMargin + 40 - 10, labelYPos,
                Width - RightMargin + 50, labelYPos);
            g.DrawString(task.Legend, font, brush,
                Width - RightMargin + 40 - 5 + 25, labelYPos - 12);
        }

        /// <summary>
        ///     Очищает зону отступа.
        /// </summary>
        /// <param name="g"></param>
        private void ClearMargins(Graphics g)
        {
            var brush = new SolidBrush(Theme.BackgroundColor);
            g.FillRectangle(brush, -1, -1, LeftMargin + 1, Height + 1);
            g.FillRectangle(brush, -1, -1, Width + 1, TopMargin + 1);
            g.FillRectangle(brush, -1, Height - BottomMargin, Width + 1, BottomMargin + 1);
            g.FillRectangle(brush, Width - RightMargin, -1, RightMargin + 1, Height + 1);
        }

        /// <summary>
        ///     Рисует координаты курсора.
        /// </summary>
        /// <param name="g"></param>
        private void DrawMousePos(Graphics g)
        {
            if (_mousePos.X != -1 || _mousePos.Y != -1)
            {
                var font = new Font("Arial", 12);
                var brush = new SolidBrush(Theme.LegendTextColor);
                string t = string.Format("X = {0:F2}\nY = {1:F2}", RawXPosToScaledValue(_mousePos.X), RawYPosToScaledValue(_mousePos.Y));
                float len = g.MeasureString(t, font).Width;
                g.DrawString(t, font, brush, Width - len, 10);
            }
        }

        /// <summary>
        ///     Обработчик события необходимости перерисовки компонента.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnPaint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Theme.BackgroundColor);
            var currentSmooth = e.Graphics.SmoothingMode == SmoothingMode.AntiAlias;
            if (Settings.SmoothDrawing != currentSmooth)
                e.Graphics.SmoothingMode = Settings.SmoothDrawing ? SmoothingMode.AntiAlias : SmoothingMode.None;

            DrawCells(e.Graphics);
            for (var j = 0; j < Tasks.Count; j++)
            {
                Plot(e.Graphics, Tasks[j], j);
            }
            ClearMargins(e.Graphics);
            for (var j = 0; j < Tasks.Count; j++)
            {
                DrawLegend(e.Graphics, Tasks[j], j, Tasks.Count);
            }
            DrawAxesLabels(e.Graphics);
            DrawCellDashes(e.Graphics);
            DrawCellLabels(e.Graphics);
            DrawAxes(e.Graphics);
            DrawAxesArrows(e.Graphics);
            DrawMousePos(e.Graphics);
        }

        /// <summary>
        ///     Класс-контейнер для хранения параметров построения одного графика.
        /// </summary>
        public class PlotTask
        {
            /// <summary>
            ///     Часть графика для построения, от 0.0 до 1.0.
            /// </summary>
            public double DrawPart = 1.0;

            /// <summary>
            ///     Легенда графика.
            /// </summary>
            public string Legend;

            /// <summary>
            ///     Отрезки для построения.
            /// </summary>
            public PointF[][] Points;
        }

        /// <summary>
        ///     Класс-контейнер для хранения настроек графопостроителя.
        /// </summary>
        public class PlotterSettings
        {
            /// <summary>
            ///     Масштаб по оси Y.
            /// </summary>
            public double ScaleY = 1.0;

            /// <summary>
            ///     Параметр, отвечающий за сглаживание.
            /// </summary>
            public bool SmoothDrawing;

            /// <summary>
            ///     Начальная координата по X.
            /// </summary>
            public double StartX;

            /// <summary>
            ///     Начальная координата по Y.
            /// </summary>
            public double StartY;

            /// <summary>
            ///     Конечная координата по X.
            /// </summary>
            public double StopX;

            /// <summary>
            ///     Конечная координата по Y.
            /// </summary>
            public double StopY;
        }

        /// <summary>
        ///     Класс темы графопостроителя.
        /// </summary>
        public class PlotterTheme
        {
            /// <summary>
            ///     Цвет стрелок у осей.
            /// </summary>
            public Color AxesArrowsColor = Color.Black;

            /// <summary>
            ///     Цвет подписей осей.
            /// </summary>
            public Color AxesLabelsColor = Color.Black;

            /// <summary>
            ///     Цвет фона.
            /// </summary>
            public Color BackgroundColor = Color.White;

            /// <summary>
            ///     Цвет текста оцифровки.
            /// </summary>
            public Color CellsLabelsColor = Color.Black;

            /// <summary>
            ///     Ручка для горизонтальных линий.
            /// </summary>
            public Pen HorizontalCellsPen = new Pen(Color.LightGray, 0.1f);

            /// <summary>
            ///     Ручка для горизонтальных штрихов.
            /// </summary>
            public Pen HorizontalDashesPen = new Pen(Color.Black, 1);

            /// <summary>
            ///     Цвет текста легенды.
            /// </summary>
            public Color LegendTextColor = Color.Black;

            /// <summary>
            ///     Массив ручек для графиков.
            /// </summary>
            public Pen[] PlotPens = { new Pen(Color.Blue, 3), new Pen(Color.Red, 3) };

            /// <summary>
            ///     Ручка для вертикальных линий.
            /// </summary>
            public Pen VerticalCellsPen = new Pen(Color.LightGray, 0.1f);

            /// <summary>
            ///     Ручка для вертикальных штрихов.
            /// </summary>
            public Pen VerticalDashesPen = new Pen(Color.Black, 1);

            /// <summary>
            ///     Ручка для оси X.
            /// </summary>
            public Pen XAxisPen = new Pen(Color.Black, 1);

            /// <summary>
            ///     Ручка для оси Y.
            /// </summary>
            public Pen YAxisPen = new Pen(Color.Black, 1);

            /// <summary>
            ///     Стандартная тема.
            /// </summary>
            public static PlotterTheme Default
            {
                get { return new PlotterTheme(); }
            }

            /// <summary>
            ///     Минималистичная тема.
            /// </summary>
            public static PlotterTheme Minimal
            {
                get
                {
                    var v = new PlotterTheme
                    {
                        AxesLabelsColor = Color.Transparent,
                        CellsLabelsColor = Color.Transparent,
                        HorizontalCellsPen = new Pen(Color.Transparent, 0.1f),
                        VerticalCellsPen = new Pen(Color.Transparent, 0.1f),
                        HorizontalDashesPen = new Pen(Color.Transparent, 1),
                        VerticalDashesPen = new Pen(Color.Transparent, 1),
                        AxesArrowsColor = Color.Transparent,
                        PlotPens = new[] { new Pen(Color.Blue, 1), new Pen(Color.Red, 1) }
                    };
                    return v;
                }
            }

            /// <summary>
            ///     Тема "Бизнес".
            /// </summary>
            public static PlotterTheme Business
            {
                get
                {
                    var v = new PlotterTheme
                    {
                        AxesLabelsColor = Color.Transparent,
                        HorizontalCellsPen = new Pen(Color.Black, 1f),
                        VerticalCellsPen = new Pen(Color.Transparent, 0.1f),
                        HorizontalDashesPen = new Pen(Color.Transparent, 1),
                        AxesArrowsColor = Color.Transparent,
                        YAxisPen = new Pen(Color.Transparent, 1),
                        PlotPens = new[] { new Pen(Color.Blue, 3), new Pen(Color.Red, 3) }
                    };
                    v.HorizontalCellsPen.DashPattern = new[] { 1f, 3f };
                    return v;
                }
            }

            /// <summary>
            ///     Тема "Маркетинг".
            /// </summary>
            public static PlotterTheme Marketing
            {
                get
                {
                    var v = new PlotterTheme
                    {
                        BackgroundColor = Color.FromArgb(255, 77, 77, 77),
                        VerticalCellsPen = new Pen(Color.Gray, 0.1f),
                        HorizontalCellsPen = new Pen(Color.Gray, 0.1f),
                        XAxisPen = new Pen(Color.Transparent, 1f),
                        YAxisPen = new Pen(Color.Transparent, 1f),
                        AxesArrowsColor = Color.Transparent,
                        LegendTextColor = Color.LightGray,
                        AxesLabelsColor = Color.Transparent,
                        CellsLabelsColor = Color.LightGray,
                        PlotPens =
                            new[]
                            {new Pen(Color.FromArgb(255, 255, 102, 0), 3), new Pen(Color.FromArgb(255, 167, 204, 0), 3)},
                        HorizontalDashesPen = new Pen(Color.Transparent),
                        VerticalDashesPen = new Pen(Color.Transparent)
                    };
                    return v;
                }
            }

            /// <summary>
            ///     Черно-белая тема.
            /// </summary>
            public static PlotterTheme Monochrome
            {
                get
                {
                    var v = new PlotterTheme
                    {
                        PlotPens = new[] { new Pen(Color.Black, 2), new Pen(Color.Black, 2) }
                    };
                    v.PlotPens[1].DashPattern = new[] { 3f, 1.5f };
                    return v;
                }
            }
        }
    }
}