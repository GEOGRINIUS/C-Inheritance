//#define CHECK_1
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Threading;
using System.Security.Cryptography;
using System.Windows.Forms.VisualStyles;

namespace AbstractGeometry
{
    class Program
    {
        struct Parameters
        {
            public Shape[] shapes;
            public PaintEventArgs e;
        }
        static bool finish = false;
        static void Main(string[] args)
        {

            IntPtr hwnd = GetConsoleWindow();
            Graphics graphics = Graphics.FromHwnd(hwnd);
            System.Drawing.Rectangle window_rect = new System.Drawing.Rectangle
                (
                    Console.WindowLeft, Console.WindowTop,
                    Console.WindowWidth, Console.WindowHeight
                );
            PaintEventArgs e = new PaintEventArgs(graphics, window_rect);
            Pen pen = new Pen(Color.AliceBlue, 5);
            e.Graphics.DrawRectangle(pen, 200, 40, 350, 130);

            ////////////////////////////////////////////////////////////////////////

#if CHECK_1
            Rectangle rectangle = new Rectangle(500, 320, 400, 200, 5, Color.Red);
            rectangle.Info(e);

            Square square = new Square(200, 500, 220, 3, Color.AliceBlue);
            square.Info(e);

            Circle circle = new Circle(100, 200, 250, 3, Color.Yellow);
            circle.Info(e); 
#endif //CHECK_1

            Shape[] shapes = new Shape[]
            {
                new Rectangle(400, 200, 400, 200, 5, Color.Red),
                new Square(200, 660, 60, 1, Color.AliceBlue),
                new Circle(150, 75, 178, 3, Color.Yellow),
                new Triangle(100, 150, 120, 130, 420, 360, 3, Color.Purple)
            };

            //Info(shapes, e);
            Parameters parameters = new Parameters()
            {
                shapes = shapes,
                e = new PaintEventArgs(graphics, window_rect)
            };
            //Draw(parameters);
            Thread draw_thread = new Thread(new ParameterizedThreadStart(Draw));
            draw_thread.Start(parameters);
            Console.ReadKey();
            finish = true;

        }
        [DllImport("Kernel32.dll")]
        public static extern IntPtr GetConsoleWindow();
        [DllImport("Kernel32.dll")]
        public static extern IntPtr GetDC(IntPtr hwnd);
        static void Info(Shape[] shapes, PaintEventArgs e)
        {
            for (int i = 0; i < shapes.Length; i++)
            {
                shapes[i].Info(e);
            }
        }
        static void Draw(object obj)
        {
            Parameters parameters = (Parameters)obj;
            while(!finish)
            {
                for(int i=0; i<parameters.shapes.Length; i++)
                {
                    parameters.shapes[i].Draw(parameters.e);
                }
            }
        }
    }
}
