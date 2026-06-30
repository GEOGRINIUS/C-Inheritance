using System;
using System.Drawing;
using System.Windows.Forms;

namespace AbstractGeometry
{
    class Triangle : Shape
    {
        public double Height { get; set; }
        public double SideA { get; set; }
        public double SideB { get; set; }
        public double SideC { get; set; }

        public Triangle(double height, double sideA, double sideB, double sideC,
                        int startX, int startY, int lineWidth, Color color)
            : base(startX, startY, lineWidth, color)
        {
            Height = height;
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
        }

        public override double GetArea()
        {
            return 0.5 * SideA * Height;
        }

        public override double GetPerimiter()
        {
            return SideA + SideB + SideC;
        }

        public override void Draw(PaintEventArgs e)
        {
            // Вычисляем горизонтальное смещение верхней вершины от левого нижнего угла
            double x = (SideB * SideB - SideC * SideC + SideA * SideA) / (2 * SideA);

            PointF pointA = new PointF(StartX, StartY);
            PointF pointB = new PointF(StartX + (float)SideA, StartY);
            PointF pointC = new PointF(StartX + (float)x, StartY - (float)Height);

            PointF[] points = { pointA, pointB, pointC };

            using (Pen pen = new Pen(Color, LineWidth))
            {
                e.Graphics.DrawPolygon(pen, points);
            }
        }

        public override void Info(PaintEventArgs e)
        {
            string info = $"Triangle: SideA={SideA:F2}, SideB={SideB:F2}, SideC={SideC:F2}, " +
                          $"Height={Height:F2}, Area={GetArea():F2}, Perimeter={GetPerimiter():F2}";

            using (Font font = new Font("Arial", 10))
            using (Brush brush = new SolidBrush(Color.Black))
            {
                // Выводим текст чуть выше левого нижнего угла
                e.Graphics.DrawString(info, font, brush, StartX, StartY - 20);
            }
        }
    }
}
