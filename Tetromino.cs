using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace MinTetris
{
    //Rotation direction
    //Напрямок повертання фігури
    public enum RotationDirection
    {
        Clockwise,
        Anticlockwise
    }
    //Rotation degree
    //Кут повертання фігури
    public enum Rotation
    {
        rotate0,
        rotate90,
        rotate180,
        rotate270
    }
    //Figure move direction
    //Напрямок руху фігури
    public enum MoveDirection
    {
        Left,
        Right,
        Down,
        Rotate
    }
    //Where should we draw the figure: on the main field or in the 'next figure' field
    //Де малювати фігуру: на основному полі чи у полі "Наступна фігура"
    public enum OutputDestination
    {
        Next,
        Glass
    }

    //Base class for all figures
    //Спільний батьківський клас для всіх фігур
    public class Tetromino
    {
        public int xPos;
        public int yPos;
        public int TetroWidth;
        public int TetroHeight;
        public int columns;
        public int nextColumns;
        public Rotation rotation;
        public MoveDirection moveDirection;
        public RotationDirection rotationDirection;
        public Color color;
        Main main;
        public Tetromino(Main main)
        {
            rotation = Rotation.rotate0;
            rotationDirection = main.rotationDirection;
            this.main = main;
            nextColumns = main.nextColumns;
        }
        //Virtual method for derived figure classes, returns the shape of the figure
        //Віртуальний метод для дочірніх фігур, повертає форму фігури
        public virtual List<int> GetLayout(OutputDestination destination)
        {
            return null;
        }
        //Movement and drawing of figure
        //Рух і малювання фігури
        public void Move(MoveDirection moveDirection)
        {
            switch (moveDirection)
            {
                case MoveDirection.Down:
                    //Check if you can move the figure
                    //перевірка можливості руху
                    if (ValidMove(moveDirection))
                    {
                        //Clear the figure after the movement
                        //Очистка фігури після руху
                        DrawTetromino(false);
                        //Move the figure
                        //рухаємо фігуру
                        yPos += 1;
                        //Set the squares as not empty where the new figure is
                        //на новому місці фігури позначаємо квадрати як зайняті
                        DrawTetromino(true);
                    }
                    //If you cannot move current figure down, generate next figure
                    //Якщо вниз рухатись не можна, то генеруємо наступну фігуру
                    else
                    {
                        main.NextTetromino();
                    }
                    break;
                case MoveDirection.Rotate:
                    if (ValidMove(moveDirection))
                    {
                        DrawTetromino(false);
                        Rotate();
                        DrawTetromino(true);
                    }
                    break;
                case MoveDirection.Right:
                    if (ValidMove(moveDirection))
                    {
                        DrawTetromino(false);
                        xPos += 1;
                        DrawTetromino(true);
                    }
                    break;
                case MoveDirection.Left:
                    if (ValidMove(moveDirection))
                    {
                        DrawTetromino(false);
                        xPos -= 1;
                        DrawTetromino(true);
                    }
                    break;
            }
            //Redraw the screen after moving the figure
            //Після руху і малювання фігури оновлюємо поле
            main.ReDraw();
        }
        //Check if the figure can move
        //Перевірка, чи можна фігурі рухатись
        private bool ValidMove(MoveDirection moveDirection)
        {
            List<int> newLayout = new List<int>();
            List<int> oldLayout = GetLayout(OutputDestination.Glass);
            switch (moveDirection)
            {
                case MoveDirection.Down:
                    //You cannot move the figure if it is near the bottom of the screen
                    //Якщо фігура біля нижнього краю ігрового поля, то рухатись не можна
                    if (yPos + TetroHeight == main.rows)
                        return false;
                    //Move the figure for evaluation purposes
                    //Рухаємо фігуру для проби
                    yPos += 1;
                    //Get the shape of the figure
                    //Отримуємо форму/розташування фігури
                    newLayout = GetLayout(OutputDestination.Glass);
                    //Cancel movement if you cannot move due to filled squares on the screen
                    //Якщо на новому місці були зафарбовані кубики, рухатись не можна, відкат руху
                    if (CollisionDetection(oldLayout, newLayout))
                    {
                        //Move figure to where if was before the check. The check showed collision
                        //повернення фігури на місце до перевірки, перевірка показала зіткнення
                        yPos -= 1;
                        return false;
                    }
                    //Move figure to where if was before the check. The check showed that the move is valid
                    //повернення фігури на місце до перевірки, перевірка показала можливість руху
                    yPos -= 1;
                    break;
                case MoveDirection.Rotate:
                    Rotation oldRotation = rotation;
                    Rotate();
                    newLayout = GetLayout(OutputDestination.Glass);
                    //Collision with screen edges
                    //Зіткнення зі стінками
                    if (xPos + TetroWidth > main.columns)
                    {
                        rotation = oldRotation;
                        return false;
                    }
                    //Collision with screen edges
                    //Зіткнення зі стінками
                    if (yPos + TetroHeight > main.rows)
                    {
                        rotation = oldRotation;
                        return false;
                    }
                    //Collision with other figures
                    //Зіткнення з іншими фігурами
                    if (CollisionDetection(oldLayout, newLayout))
                    {
                        rotation = oldRotation;
                        return false;
                    }
                    rotation = oldRotation;
                    break;
                case MoveDirection.Right:
                    if (xPos + TetroWidth == main.columns)
                        return false;
                    xPos += 1;
                    newLayout = GetLayout(OutputDestination.Glass);
                    if (CollisionDetection(oldLayout, newLayout))
                    {
                        xPos -= 1;
                        return false;
                    }
                    xPos -= 1;
                    break;
                case MoveDirection.Left:
                    if (xPos == 0) return false;
                    xPos -= 1;
                    newLayout = GetLayout(OutputDestination.Glass);
                    if (CollisionDetection(oldLayout, newLayout))
                    {
                        xPos += 1;
                        return false;
                    }
                    xPos += 1;
                    break;
            }
            return true;
        }
        //Check if there are obstacles on the path of the figure
        //Перевірка на наявність на шляху руху фігури перешкод
        private bool CollisionDetection(List<int> oldLayout, List<int> newLayout)
        {
            //Make a list of squares that are different before and after the movement
            //Створення списку квадратиків, які відрізняються до руху і після руху
            List<int> collisionDetection = new List<int>();
            foreach (int square in newLayout)
            {
                if (oldLayout.Contains(square)) continue;
                collisionDetection.Add(square);
            }
            //Compare the list of different squares with the screen and find filled squares that are the same (collision)
            //Порівняння цього списку відмінних квадратиків з ігровим полем і знаходження співпадінь (зіткнень)
            foreach (int square in collisionDetection)
            {
                //Collision detected
                //Зіткнення
                if (!main.glass[square].empty) return true;
            }
            //No collision
            //Зіткнення немає
            return false;
        }
        //Is there free space on the screen for the new figure
        //Чи є на полі місце для створення нової фігури
        public bool CanItFit()
        {
            foreach (int idx in GetLayout(OutputDestination.Glass))
            {
                if (!main.glass[idx].empty) return false;
            }
            return true;
        }
        //Fill the squares where the figure is
        //If the argument is false, mark the squares as empty
        //if it is true, mark the squares as not empty and fill them with figure color

        //Позначення квадратів на полі, де знаходиться фігура
        //Якщо аргумент false, то позначати квадрати як вільні,
        //якщо true, то позначати квадрати як зайняті та фарбувати їх у колір фігури
        public void DrawTetromino(bool onOff)
        {
            bool toggle = onOff;
            foreach (int idx in GetLayout(OutputDestination.Glass))
            {
                main.glass[idx].empty = !toggle;
                if(!toggle) main.glass[idx].color = main.BackgroundColor;
                else main.glass[idx].color = color;
            }
            main.ReDraw();
        }
        //Filling squares with color in the 'next figure' screen
        //Зафарбовування квадратів у вікні "Наступна фігура"
        public void DrawNext()
        {
            foreach (int idx in GetLayout(OutputDestination.Next))
            {
                main.nextGlass[idx].empty = false;
                main.nextGlass[idx].color = main.nextTetrominoColor;
            }
            main.ReDraw();
        }
        //Figure rotation logic        
        //Що робити при повертанні фігури: зміна перемінної, від якої залежить просторове
        //розташування фігури на ігровому полі
        private void Rotate()
        {
            switch (rotation)
            {
                case Rotation.rotate0:
                    switch (rotationDirection)
                    {
                        case RotationDirection.Clockwise:
                            rotation = Rotation.rotate90;
                            break;
                        case RotationDirection.Anticlockwise:
                            rotation = Rotation.rotate270;
                            break;
                    }
                    break;
                case Rotation.rotate90:
                    switch (rotationDirection)
                    {
                        case RotationDirection.Clockwise:
                            rotation = Rotation.rotate180;
                            break;
                        case RotationDirection.Anticlockwise:
                            rotation = Rotation.rotate0;
                            break;
                    }
                    break;
                case Rotation.rotate180:
                    switch (rotationDirection)
                    {
                        case RotationDirection.Clockwise:
                            rotation = Rotation.rotate270;
                            break;
                        case RotationDirection.Anticlockwise:
                            rotation = Rotation.rotate90;
                            break;
                    }
                    break;
                case Rotation.rotate270:
                    switch (rotationDirection)
                    {
                        case RotationDirection.Clockwise:
                            rotation = Rotation.rotate0;
                            break;
                        case RotationDirection.Anticlockwise:
                            rotation = Rotation.rotate180;
                            break;
                    }
                    break;
            }
        }
    }
}
