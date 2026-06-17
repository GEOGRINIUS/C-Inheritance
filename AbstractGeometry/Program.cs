using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Runtime.InteropServices;
using System.Drawing.Design;
using System.Windows.Forms;

namespace AbstractGeometry
{
    class Program
    {
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
            e.Graphics.DrawRectangle(pen, 300, 100, 250, 130);

            ////////////////////////////////////////////////////////////////////////

            Rectangle rectangle = new Rectangle(500, 320, 400, 200, 5, Color.Red);
            rectangle.Info(e);
        }
        [DllImport("Kernel32.dll")]
        public static extern IntPtr GetConsoleWindow();
        [DllImport("Kernel32.dll")]
        public static extern IntPtr GetDC(IntPtr hwnd);
    }
}
