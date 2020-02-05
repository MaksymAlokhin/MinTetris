using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;


namespace MinTetris
{
    //Square as the smallest part of game screen
    //Клас, який представляє найменший кубик ігрового поля
    public class Square: Tetromino
    {
        public bool empty;
        public Rectangle rectangle;
        private int sq;
        public Square(Main main) : base(main)
        {
            empty = true;
            rectangle = Rectangle.Empty;
            color = main.BackgroundColor;
            sq = main.squareDimensions;
        }
        //Draw a square
        //Малювання кубика
        public void Draw(Graphics g)
        {
            int top = rectangle.Top;
            int bottom = rectangle.Bottom;
            int left = rectangle.Left;
            int right = rectangle.Right;
            SolidBrush brush = new SolidBrush(color);
            //Fill square with color
            //Залиття кубика кольором
            g.FillRectangle(brush, rectangle.Left+2, rectangle.Top+2, rectangle.Width-3, rectangle.Height-3);

            //Color adjustments for 3D effect of the square
            //Вибір темніших і світліших відтінків для ефекту об'ємності
            Pen penLight = new Pen(Adjust(color, 1.5));
            Pen penDark = new Pen(Adjust(color, 0.5));
            
            //Draw outer borders of the square
            //Малювання зовнішньої границі
            g.DrawLine(penLight, left + 1, bottom - 1, left + 1, top + 1);
            g.DrawLine(penLight, left + 1, top + 1, right - 1, top + 1);
            g.DrawLine(penDark, right - 1, top + 1, right - 1, bottom - 1);
            g.DrawLine(penDark, right - 1, bottom - 1, left + 1, bottom - 1);
            //Draw inner borders of the square (the 'hollow' part)
            //Малювання "вдавленої" серцевинки кубика
            g.DrawLine(penLight, right - sq / 3, top + sq / 3, right - sq / 3, bottom - sq / 3);
            g.DrawLine(penLight, right - sq / 3, bottom - sq / 3, left + sq / 3, bottom - sq / 3);
            g.DrawLine(penDark, left + sq / 3, bottom - sq / 3, left + sq / 3, top + sq / 3);
            g.DrawLine(penDark, left + sq / 3, top + sq / 3, right - sq / 3, top + sq / 3);
            brush.Dispose(); //Звільнення ресурсів
            penLight.Dispose(); //Freeing resources
            penDark.Dispose();
        }
        //Creating darker/lighter shades of color for the square
        //Створення темнішого чи світлішого відтінку кольору кубика
        private Color Adjust (Color color, double adjust)
        {
            Color c;
            var a = color.A;
            var r = Clamp((int)(color.R * adjust));
            var g = Clamp((int)(color.G * adjust));
            var b = Clamp((int)(color.B * adjust));
            c = Color.FromArgb(a,r,g,b);
            return c;
        }
        //Clamping the color value to 0-255
        //Обмеження коду кольору у діапазоні 0 - 255
        private int Clamp(int value)
        {
            return (value < 0) ? 0 : (value > 255) ? 255 : value;
        }
    }
}
