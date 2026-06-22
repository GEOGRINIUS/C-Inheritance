using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Windows.Forms;

namespace AbstractGeometry
{
    class Square: Rectangle
    {
       public Square
          (
               double side,
               int startX, int startY, int linewidth,
               Color color
          ):base(side, side, startX, startY, linewidth, color)
        { }
    }
}
