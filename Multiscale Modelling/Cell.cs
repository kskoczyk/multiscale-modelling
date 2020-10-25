using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiscale_Modelling
{
    public class Cell
    {
        public int Type { get; set; }
        public Point Position { get; private set; } = new Point(0, 0);
    }
}
