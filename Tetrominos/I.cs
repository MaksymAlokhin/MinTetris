using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace MinTetris
{
    class I : Tetromino
    {
        public I(Main main) : base(main)
        {
            color = main.IColor;
            columns = main.columns;
            xPos = (columns - 1) / 2;
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
                    layout.Add(position);
                    layout.Add(position + columns);
                    layout.Add(position + columns * 2);
                    layout.Add(position + columns * 3);
                    TetroWidth = 1;
                    TetroHeight = 4;
                    break;
                case Rotation.rotate90:
                case Rotation.rotate270:
                    layout.Add(position);
                    layout.Add(position + 1);
                    layout.Add(position + 2);
                    layout.Add(position + 3);
                    TetroWidth = 4;
                    TetroHeight = 1;
                    break;
            }
            return layout;
        }
    }
}
