using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Windows.Forms;

namespace AbstractGeometry
{
    class Circle:Shape, IHaveDiameter
    {
        public double Radius { get; set; }
        public Circle
            (
                double radius,
                int startX, int startY, int linewidth, Color color
            ) : base(startX, startY, linewidth, color) 
        {
            this.Radius = radius;
        }
        public override double GetArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }
        public override double GetPerimiter()
        {
            return Math.PI * Radius * 2;
        }
        public double GetDiameter()
        {
            return 2 * Radius;
        }
        public override void Draw(PaintEventArgs e)
        {
            Pen pen = new Pen(Color, LineWidth);
            e.Graphics.DrawEllipse(pen, StartX, StartY, (float)Radius * 2, (float)Radius * 2);
        }
        public void DrawRadius(PaintEventArgs e)
        {
            Pen pen = new Pen(Color, 1);
            e.Graphics.DrawLine
                (
                pen,
                StartX + (int)Radius, StartY + (int)Radius,
                StartX + (int)Radius + (int)(Radius * Math.Cos(210*Math.PI/180)), 
                StartY + (int)Radius + (int)(Radius * Math.Sin(210*Math.PI/180))
                );
        }
        public void DrawDiameter(PaintEventArgs e)
        {
            Pen pen = new Pen(Color, 1);
            e.Graphics.DrawLine
                (
                pen, 
                StartX + (int)Radius + (int)(Radius   * Math.Sin(210*Math.PI/180)),
                StartY + (int)Radius + (float)(Radius * Math.Cos(210*Math.PI/180)),

                StartX + (int)Radius + (float)(Radius * Math.Cos(30*Math.PI/180)), 
                StartY + (int)Radius + (float)(Radius * Math.Sin(30*Math.PI/180))
                );
        }
        public override void Info(PaintEventArgs e)
        {
            Console.WriteLine($"Радиус: {Radius}");
            Console.WriteLine($"Диаметр: {GetDiameter()}");
            DrawRadius(e);
            DrawDiameter(e);
            base.Info(e);
        }
    }
}
