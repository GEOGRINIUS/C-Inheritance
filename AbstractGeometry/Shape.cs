using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Windows.Forms;

namespace AbstractGeometry
{
    abstract class Shape
    {
        protected int StartX { get; set; }
        protected int StartY { get; set; }
        protected int LineWidth { get; set; }
        protected Color Color { get; set; }
        public Shape(int startX, int startY, int lineWidth, Color color)
        {
            this.StartX = startX;
            this.StartY = startY;
            this.LineWidth = lineWidth;
            this.Color = color;
        }
        public abstract double GetArea();
        public abstract double GetPerimiter();
        public abstract void Draw(PaintEventArgs e);
        public virtual void Info(PaintEventArgs e)
        {
            Console.WriteLine($"Площадь фигуры: {GetArea()}");
            Console.WriteLine($"Периметр фигуры: {GetPerimiter()}");
            Draw(e);
        }
    }
}
