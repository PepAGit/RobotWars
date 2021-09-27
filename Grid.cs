using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace RobotWars
{
    class Grid
    {
        public Grid()
        {
            Origin = new Point(0, 0);
            GridCellSize = new Size(10, 10);
            HorizontalCells = 1;
            VerticalCells = 1;
        }

        public int HorizontalCells { get; set; }
        public int VerticalCells { get; set; }
        public Point Origin { get; set; }
        public Size GridCellSize { get; set; }

    }
}
