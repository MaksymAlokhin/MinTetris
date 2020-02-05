using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace MinTetris
{
    class O : Tetromino
    {
        public O(Main main) : base(main)
        {
            color = main.OColor;
            columns = main.columns;
            xPos = (columns - 2) / 2;
            yPos = 0;
        }

        public override List<int> GetLayout(OutputDestination destination)
        {
            int position;
            List<int> layout = new List<int>();
            position = xPos + yPos * columns;
            if (destination == OutputDestination.Next)
            {
                position = 0;
                columns = nextColumns;
            }
            switch (rotation)
            {
                case Rotation.rotate0:
                case Rotation.rotate180:
                case Rotation.rotate90:
                case Rotation.rotate270:
                    layout.Add(position);
                    layout.Add(position + 1);
                    layout.Add(position + columns);
                    layout.Add(position + columns + 1);
                    TetroWidth = 2;
                    TetroHeight = 2;
                    break;
            }
            return layout;
        }
    }
}
