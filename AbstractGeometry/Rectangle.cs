using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Windows.Forms;

namespace AbstractGeometry
{
    class Rectangle: Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public Rectangle
            (
                double width, double height,
                int startX, int startY, int linewidth, Color color
            ) : base(startX, startY, linewidth, color)
        {
            Width = width;
            Height = height;
        }
        public override double GetArea()
        {
            return Width * Height;
        }
        public override double GetPerimiter()
        {
            return 2 * (Width + Height);
        }
        public override void Draw(PaintEventArgs e)
        {
            //Console.WriteLine("Нужно нарисовать прямоугольник");
            Pen pen = new Pen(Color, LineWidth);
            e.Graphics.DrawRectangle(pen, StartX, StartY, (float)Width, (float)Height);
        }
        public override void Info(PaintEventArgs e)
        {
            Console.WriteLine($"Ширина прямоугольника: {Width}");
            Console.WriteLine($"Высота прямоугольника: {Height}");
            base.Info(e);
        }
    }
}
