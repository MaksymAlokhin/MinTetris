using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Timers;

namespace MinTetris
{
    //Main logic is here
    //Головний клас, логіка програми тут
    public partial class Main : Form
    {
        //Figure colors
        //кольори фігур
        public Color IColor;
        public Color JColor;
        public Color LColor;
        public Color OColor;
        public Color SColor;
        public Color TColor;
        public Color ZColor;
        public Color pFColor;
        public Color pFmColor;
        public Color pIColor;
        public Color pLColor;
        public Color pLmColor;
        public Color pNColor;
        public Color pNmColor;
        public Color pPColor;
        public Color pPmColor;
        public Color pTColor;
        public Color pUColor;
        public Color pVColor;
        public Color pWColor;
        public Color pXColor;
        public Color pYColor;
        public Color pYmColor;
        public Color pZColor;
        public Color pZmColor;
        public Color pHelperColor;
        public Color BackgroundColor;
        public Color nextTetrominoColor;

        //# of rows
        //рядків
        public int rows;
        //# of columns
        //стовпців
        public int columns;
        //'next figure' screen rows
        //рядків у вікні показу наступної фігури
        public int nextRows;
        //'next figure' screen columns
        //стовпців у вікні показу наступної фігури
        public int nextColumns;
        //Square side size in pixels
        //розміри кубика
        public int squareDimensions;

        //Keyboard controls
        //клавіши управління
        private Keys moveDownKey;
        private Keys moveRightKey;
        private Keys moveLeftKey;
        private Keys rotateKey;
        private Keys pauseKey;

        //Rotation direction
        //напрямок повертання
        public RotationDirection rotationDirection;

        //You start at this level
        //початковий рівень
        private int startingLevel;
        //You start at this speed
        //початкова швидкість
        private int startingSpeed;
        //Speed increase with each level
        //збільшення швидкості з кожним рівнем
        private int speedIncrease;
        //New level after n cleared lines
        //перехід на новий рівень через n ліній
        private int newLevelThreshold;
        //Score for clearing n lines
        //очки за очищення n ліній
        private int bonus1;
        private int bonus2;
        private int bonus3;
        private int bonus4;
        //Help player with a Help figure after n figures
        //через кожні n фігур допомагати гравцю
        private int pentoHelper;
        //Counter for Help figure
        //лічильник для допомоги гравцю
        private int pentoCounter;

        //Current figure
        //поточна фігура
        private Tetromino currentTetromino;
        //Next figure
        //наступна фігура
        private Tetromino nextTetromino;
        //Game started flag
        //чи почалася гра
        private bool gameStarted;
        //Pause flag
        //чи пауза
        private bool gamePaused;
        //Display Grid on the game screen flag
        //чи показувати сітку
        private bool GridEnabled;
        //Game screen container
        //контейнер для ігрового поля
        public List<Square> glass;
        //'Next figure' screen container
        //контейнер для допоміжного вікна
        public List<Square> nextGlass;

        //Figure drop timer
        //таймер падіння
        private System.Timers.Timer DropTimer;

        //Random number for choosing the next figure
        //випадкове число для вибору наступної фігури
        private Random random;

        //Plyer score
        //очки
        private int score;
        //How many lines were cleared
        //ліній очищено
        private int lines;
        //How many lines were cleared at once
        //очищено одночасно
        private int comboLines;
        //Game level
        //рівень
        private int level;

        private string helpText = "Use arrow keys.\n[P] to pause";
        public Main()
        {
            InitializeComponent();
            //Load settings
            //завантаження налаштувань
            LoadSettings();
            //Initialize settings
            //ініціалізація налаштувань
            ApplySize();

            random = new Random();

            //Double buffer to avoid screen flickering (StackOverflow)
            //запобігання мерехтінню при оновленні екрану. Подвійний буфер (StackOverflow)
            System.Reflection.PropertyInfo antiFlicker = typeof(System.Windows.Forms.Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            antiFlicker.SetValue(GlassPanel, true, null);

            //Key press event handler
            //Оброблювач подій натискання клавіш
            this.KeyDown += new KeyEventHandler(this.Main_KeyDown);

            //Timer for figure to move down
            //Таймер для падіння фігур
            DropTimer = new System.Timers.Timer();
            DropTimer.Enabled = false;
            DropTimer.Elapsed += OnDropTimerTick;
        }
        //Menu 'Start game'
        //Пункт меню "Початок гри"
        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Load settings
            //завантаження налаштування
            LoadSettings();
            //Initialize settings
            //ініціалізація налаштувань
            ApplySize();
            score = 0;
            lines = 0;
            level = startingLevel;
            //Set the falling speed
            //встановлення швидкості падіння
            UpdateSpeed();
            //Show score, number of cleared lines and game level
            //показ очків, кількості знищених ліній та рівня
            DisplayInfoText();
            //Create main screen
            //створення ігрового поля
            MakeGlass();
            //Create screen to show next figure
            //створення поля для показу наступної фігури
            MakeNextGlass();
            //Select current figure
            //вибір поточної фігури
            currentTetromino = GenerateTetromino();
            //Draw current figure
            //малювання поточної фігури
            currentTetromino.DrawTetromino(true);
            //Helper figure counter
            //помічник гравця
            pentoCounter = pentoHelper - 1;
            //Choose next figure
            //вибір наступної фігури
            nextTetromino = GenerateTetromino();
            //Draw next figure
            //малювання наступної фігури
            nextTetromino.DrawNext();
            //Screen refresh
            //оновлення поля
            ReDraw();
            //Game started flag
            //прапорець початку гри
            gameStarted = true;
            //Game paused flag
            //Прапорець паузи
            gamePaused = false;
            //Drop timer start
            //запуск таймера падіння фігур
            DropTimer.Enabled = true;
            //Show score
            //показ тексту про рахунок
            DisplayInfoText();
        }
        //Load settings from file
        //Завантаження налаштувань з файлу
        public void LoadSettings()
        {
            SettingsForm sf = new SettingsForm(this);
            Settings set = sf.InitializeSettings();
            rows = set.Rows;
            columns = set.Columns;
            squareDimensions = set.SquareDimensions;
            moveDownKey = set.MoveDownKey;
            moveRightKey = set.MoveRightKey;
            moveLeftKey = set.MoveLeftKey;
            rotateKey = set.RotateKey;
            pauseKey = set.PauseKey;
            IColor = set.IColor;
            JColor = set.JColor;
            LColor = set.LColor;
            OColor = set.OColor;
            SColor = set.SColor;
            TColor = set.TColor;
            ZColor = set.ZColor;
            pFColor = set.PFColor;
            pFmColor = set.PFmColor;
            pIColor = set.PIColor;
            pLColor = set.PLColor;
            pLmColor = set.PLmColor;
            pNColor = set.PNColor;
            pNmColor = set.PNmColor;
            pPColor = set.PPColor;
            pPmColor = set.PPmColor;
            pTColor = set.PTColor;
            pUColor = set.PUColor;
            pVColor = set.PVColor;
            pWColor = set.PWColor;
            pXColor = set.PXColor;
            pYColor = set.PYColor;
            pYmColor = set.PYmColor;
            pZColor = set.PZColor;
            pZmColor = set.PZmColor;
            pHelperColor = set.PHelperColor;
            BackgroundColor = set.BackgroundColor;
            rotationDirection = set.RotationDir;
            startingLevel = set.StartingLevel;
            GridEnabled = set.GridEnabled;
            startingSpeed = set.StartingSpeed;
            speedIncrease = set.SpeedIncrease;
            newLevelThreshold = set.NewLevelThreshold;
            bonus1 = set.Bonus1;
            bonus2 = set.Bonus2;
            bonus3 = set.Bonus3;
            bonus4 = set.Bonus4;
            nextColumns = 5;
            nextRows = 5;
            pentoHelper = set.PentoHelper;
        }
        //Change Form size when applying settings
        //Зміна розміру вікон програми при зміні налаштувань розміру ігрового поля
        public void ApplySize()
        {
            //Freeze screen changes
            //заморожування вікна
            SuspendLayout();
            GlassPanel.BackColor = BackgroundColor;
            GlassPanel.Width = columns * squareDimensions;
            GlassPanel.Height = rows * squareDimensions;
            InfoPanel.Width = 220;
            InfoPanel.Height = GlassPanel.Height;
            NextTetrominoPanel.Width = nextColumns * squareDimensions;
            NextTetrominoPanel.Height = nextRows * squareDimensions;
            Width = GlassPanel.Width + InfoPanel.Width + 32;
            Height = GlassPanel.Height + 80;
            NextTetrominoPanel.Location = new Point((InfoPanel.Width - NextTetrominoPanel.Width)/2, 30);
            HelpText.Width = InfoPanel.Width - 4;
            HelpText.Location = new Point(2, NextTetrominoPanel.Bottom + 2);
            scoresPanel.Width = InfoPanel.Width - 4;
            scoresPanel.Location = new Point(2, HelpText.Bottom + 2);
            nextLabel.Location = new Point((InfoPanel.Width - nextLabel.Width)/2, 2);
            InfoPanel.Location = new Point(GlassPanel.Right, 30);
            //Unfreeze screen
            //вікно може оновлюватись
            ResumeLayout();
            //Refresh screen
            //оновлення вікна
            Refresh();
        }
        //Move figure down according to timer
        //Рух фігури вниз по таймеру
        private void OnDropTimerTick(Object source, ElapsedEventArgs e)
        {
            //Move down
            //рух вниз
            if (gameStarted) currentTetromino.Move(MoveDirection.Down);
            //Redraw the game screen
            //оновлення ігрового поля
            ReDraw();
        }
        //Events when changing figure for the next
        //Події при необхідності змінити фігуру на наступну
        public void NextTetromino()
        {
            currentTetromino = nextTetromino;
            currentTetromino.columns = columns;
            if (gameStarted)
            {
                //Check if there is space on the screen to put a new figure
                //перевірка, чи нова фігура поміститься на поле
                if (!currentTetromino.CanItFit()) GameOver();
            }
            if (gameStarted)
            {
                //Stop the timer
                //зупинка таймера
                DropTimer.Stop();
                comboLines = 0;
                //Clear filled lines
                //Очищення повних ліній
                for (int row = 0; row < rows; ++row)
                {
                    if (CheckLine(row))
                    {
                        ClearLine(row);
                        ++comboLines;
                        ++lines;
                    }
                }
                //Refresh score
                //Оновлення рахунку
                UpdateScore();
                //Refresh level
                //оновлення рівня
                UpdateLevel();
                //Show score
                //показ тексту про рахунок
                DisplayInfoText();
                //Draw figure
                //малювання фігури
                currentTetromino.DrawTetromino(true);
                //Chose next figure
                //вибір наступної фігури
                nextTetromino = GenerateTetromino();
                //Clear 'next figure' window
                //очищення вікна наступної фігури
                MakeNextGlass();
                //Draw next figure
                //малювання наступної фігури
                nextTetromino.DrawNext();
                //Redraw screen
                //оновлення екрану
                ReDraw();
                //Start timer
                //відновлення таймера
                DropTimer.Start();
            }
        }
        //Keyboard event handler
        //Обробка натискання клавіш
        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            Keys k = e.KeyCode;
            if (gameStarted && !gamePaused)
            {
                if      (k == moveDownKey) currentTetromino.Move(MoveDirection.Down);
                else if (k == moveRightKey) currentTetromino.Move(MoveDirection.Right);
                else if (k == moveLeftKey) currentTetromino.Move(MoveDirection.Left);
                else if (k == rotateKey) currentTetromino.Move(MoveDirection.Rotate);
            }
            if (gameStarted)
            {
                if (k == pauseKey) PauseToggle();
            }
        }
        //Chose next figure
        //Вибір наступної фігури
        private Tetromino GenerateTetromino()
        {
            int rng;
            Tetromino generatedTetromino = new Tetromino(this);
            //'Tetromino' mode figures
            //Фігури для режиму "Тетроміно"
            if (tetroMenu.Checked)
            {
                rng = random.Next(0, 7);
                switch (rng)
                {
                    case 0:
                        generatedTetromino = new I(this);
                        nextTetrominoColor = IColor;
                        break;
                    case 1:
                        generatedTetromino = new O(this);
                        nextTetrominoColor = OColor;
                        break;
                    case 2:
                        generatedTetromino = new T(this);
                        nextTetrominoColor = TColor;
                        break;
                    case 3:
                        generatedTetromino = new J(this);
                        nextTetrominoColor = JColor;
                        break;
                    case 4:
                        generatedTetromino = new L(this);
                        nextTetrominoColor = LColor;
                        break;
                    case 5:
                        generatedTetromino = new S(this);
                        nextTetrominoColor = SColor;
                        break;
                    case 6:
                        generatedTetromino = new Z(this);
                        nextTetrominoColor = ZColor;
                        break;
                }
            }
            //'Pentomino' mode figures
            //Фігури для режиму "Пентоміно"
            if (pentoMenu.Checked)
            {
                rng = random.Next(0, 18);
                pentoCounter -= 1;
                if (pentoCounter == 0)
                {
                    pentoCounter = pentoHelper;
                    generatedTetromino = new pHelper(this);
                    nextTetrominoColor = pHelperColor;
                }
                else switch (rng)
                {
                    case 0:
                        generatedTetromino = new pF(this);
                        nextTetrominoColor = pFColor;
                        break;
                    case 1:
                        generatedTetromino = new pFm(this);
                        nextTetrominoColor = pFmColor;
                        break;
                    case 2:
                        generatedTetromino = new pI(this);
                        nextTetrominoColor = pIColor;
                        break;
                    case 3:
                        generatedTetromino = new pL(this);
                        nextTetrominoColor = pLColor;
                        break;
                    case 4:
                        generatedTetromino = new pLm(this);
                        nextTetrominoColor = pLmColor;
                        break;
                    case 5:
                        generatedTetromino = new pN(this);
                        nextTetrominoColor = pNColor;
                        break;
                    case 6:
                        generatedTetromino = new pNm(this);
                        nextTetrominoColor = pNmColor;
                        break;
                    case 7:
                        generatedTetromino = new pP(this);
                        nextTetrominoColor = pPColor;
                        break;
                    case 8:
                        generatedTetromino = new pPm(this);
                        nextTetrominoColor = pPmColor;
                        break;
                    case 9:
                        generatedTetromino = new pT(this);
                        nextTetrominoColor = pTColor;
                        break;
                    case 10:
                        generatedTetromino = new pU(this);
                        nextTetrominoColor = pUColor;
                        break;
                    case 11:
                        generatedTetromino = new pV(this);
                        nextTetrominoColor = pVColor;
                        break;
                    case 12:
                        generatedTetromino = new pW(this);
                        nextTetrominoColor = pWColor;
                        break;
                    case 13:
                        generatedTetromino = new pX(this);
                        nextTetrominoColor = pXColor;
                        break;
                    case 14:
                        generatedTetromino = new pY(this);
                        nextTetrominoColor = pYColor;
                        break;
                    case 15:
                        generatedTetromino = new pYm(this);
                        nextTetrominoColor = pYmColor;
                        break;
                    case 16:
                        generatedTetromino = new pZ(this);
                        nextTetrominoColor = pZColor;
                        break;
                    case 17:
                        generatedTetromino = new pZm(this);
                        nextTetrominoColor = pZmColor;
                        break;
                }
            }
            return generatedTetromino;
        }
        //Generate the game screen
        //Генерування ігрового поля
        private void MakeGlass()
        {
            glass = new List<Square>();
            int idx = 0;
            for (int i = 0; i < rows * squareDimensions; i += squareDimensions)
            {
                for (int j = 0; j < columns * squareDimensions; j += squareDimensions)
                {
                    glass.Add(new Square(this));
                    glass[idx].rectangle = new Rectangle(j, i, squareDimensions, squareDimensions);
                    ++idx;
                }
            }
        }
        //Generate 'next figure' screen
        //Генерування поля для показу наступної фігури
        private void MakeNextGlass()
        {
            nextGlass = new List<Square>();
            int idx = 0;
            for (int i = 0; i < nextRows * squareDimensions; i += squareDimensions)
            {
                for (int j = 0; j < nextColumns * squareDimensions; j += squareDimensions)
                {
                    nextGlass.Add(new Square(this));
                    nextGlass[idx].rectangle = new Rectangle(j, i, squareDimensions, squareDimensions);
                    ++idx;
                }
            }
        }
        //Check if the line is filled
        //Перевірка, чи заповнена лінія
        private bool CheckLine (int row)
        {
            for (int idx = row * columns; idx < row * columns + columns; ++idx)
            {
                if (glass[idx].empty) return false;
            }
            return true;
        }
        //Clear the filled line
        //Очищення лінії
        private void ClearLine (int row)
        {
            for (int idx = row * columns; idx < row * columns + columns; ++idx) //очищення
            {
                glass[idx].empty = true;
                glass[idx].color = BackgroundColor;
            }
            ScrollLines(row);
        }
        //Scroll upper lines down
        //Зсув верхніх ліній вниз
        private void ScrollLines(int row)
        {
            for (int idx = row * columns + columns - 1; idx >= 0; --idx) //зсув
            {
                if (!glass[idx].empty)
                {
                    Color cBuffer;
                    glass[idx].empty = true;
                    cBuffer = glass[idx].color;
                    glass[idx].color = BackgroundColor;
                    glass[idx + columns].empty = false;
                    glass[idx + columns].color = cBuffer;
                }
            }
        }
        //Update score
        //Оновлення рахунку
        private void UpdateScore()
        {
            if (comboLines == 1) score += bonus1;
            if (comboLines == 2) score += bonus2;
            if (comboLines == 3) score += bonus3;
            if (comboLines == 4) score += bonus4;
        }
        //Update level
        //Оновлення рівня
        private void UpdateLevel()
        {
            if (startingLevel < lines / newLevelThreshold)
            {
                level = lines / newLevelThreshold;
                UpdateSpeed();
            }
        }
        //Update speed
        //Оновлення швидкості
        private void UpdateSpeed()
        {
            int interval = startingSpeed - level * speedIncrease;
            if (interval > 0) DropTimer.Interval = interval;
        }
        //Show game information: score, cleared lines, level
        //Delegates are used to avoid thread concurrency error (StackOverflow)
        //Показ тексту про стан гри: рахунок, очищено ліній, рівень
        //Використані делегати, т.к. інакше виникає помилка про конфлікт потоків (StackOverflow)
        private void DisplayInfoText()
        {
            ScoreIndicator.Invoke((MethodInvoker)(() =>
            {
                ScoreIndicator.Text = score.ToString();
            }));
            LinesIndicator.Invoke((MethodInvoker)(() =>
            {
                LinesIndicator.Text = lines.ToString();
            }));
            LevelIndicator.Invoke((MethodInvoker)(() =>
            {
                LevelIndicator.Text = level.ToString();
            }));
            SpeedIndicator.Invoke((MethodInvoker)(() =>
            {
                SpeedIndicator.Text = (startingSpeed - DropTimer.Interval).ToString();
            }));
            if (gameStarted)
            {
                HelpText.Invoke((MethodInvoker)(() =>
                {
                    HelpText.Text = helpText;
                }));
            } 
        }
        //Redraw game screens
        //Оновлення ігрового поля та вікна наступної фігури
        public void ReDraw()
        {
            GlassPanel.Invalidate();
            NextTetrominoPanel.Invalidate();
        }
        //Paint event handler for game screen
        //Оброблювач подій "Малювання" для основного вікна
        private void GlassPanel_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.DimGray);
            e.Graphics.DrawRectangle(pen, 0, 0, GlassPanel.Width - 1, GlassPanel.Height - 1); //рамка навколо вікна
            pen.Dispose();

            Graphics g = e.Graphics;
           
            if (gameStarted)
            {
                foreach (Square square in glass)
                {
                   if(GridEnabled) square.Draw(g);
                   else if (!square.empty) square.Draw(g);
                }
            }
        }
        //Paint event handler for 'next figure' screen
        //Оброблювач подій "Малювання" для вікна показу наступної фігури
        private void NextTetrominoPanel_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.DimGray);
            //Draw the frame for game screen
            //Малювання рамки
            e.Graphics.DrawRectangle(pen, 0, 0, NextTetrominoPanel.Width - 1, NextTetrominoPanel.Height - 1);
            pen.Dispose();

            Graphics g = e.Graphics;
            if (gameStarted)
            {
                foreach (Square square in nextGlass)
                {
                    if (GridEnabled) square.Draw(g);
                    else if (!square.empty) square.Draw(g);
                }
            }
        }
        //Paint event handler for Information Panel
        //Оброблювач подій "Малювання" для інформаційного вікна
        private void InfoPanel_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.DimGray);
            e.Graphics.DrawRectangle(pen, 0, 0, InfoPanel.Width - 1, InfoPanel.Height - 1); //Рамка
            pen.Dispose();
        }
        //What to do when the program loads
        //Дії при запуску програми
        private void MainWindow_Load(object sender, EventArgs e)
        {
            
        }
        //'Exit game' menu
        //Натискання меню "Вийти з програми"
        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //'Pause' menu
        //Натискання меню "Пауза"
        private void pauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PauseToggle();
        }
        //Pause toggle
        //Перемикання паузи
        private void PauseToggle()
        {
            if (DropTimer.Enabled)
            {
                DropTimer.Stop();
                HelpText.Text = "PAUSED\nPress [P] to unpause";
                gamePaused = true;
            }
            else
            {
                HelpText.Text = helpText;
                DropTimer.Start();
                gamePaused = false;
            }
        }
        //'End game' menu
        //Меню "Завершити гру"
        private void endToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GameOver();
        }
        //Ending game process
        //Процедура завершення гри
        private void GameOver()
        {
            gameStarted = false;
            gamePaused = false;
            DropTimer.Stop();
            DropTimer.Enabled = false;
            //Using delegates because of thread concurrency error (StackOverflow)
            //Через помилку "Конфлікт потоків", використовуємо делегатів (StackOverflow)
            HelpText.Invoke((MethodInvoker)(() =>
            {
                HelpText.Text = "GAME OVER";
            }));
            //Clear the game screen
            //очистка ігрового вікна
            MakeGlass();
            //Clear 'next figure' screen
            //очистка вікна наступної фігури
            MakeNextGlass();
            HelpText.Invoke((MethodInvoker)(() =>
            {
                ShowHighScores();
            }));
            score = 0;
            lines = 0;
            level = 0;
            DisplayInfoText();
            SpeedIndicator.Invoke((MethodInvoker)(() =>
            {
                SpeedIndicator.Text = "0";
            }));
            //Redraw game screen
            //оновлення вікна програми
            ReDraw();
        }
        //Show highscores
        //Показ найкращих гравців
        private void ShowHighScores()
        {
            if (tetroMenu.Checked)
            {
                HighScores hs = new HighScores("tetro");
                var selectedPlayers = from p in hs.highScoresList
                         where p.gameType == "Tetromino"
                         select p;
                foreach (Player p in selectedPlayers)
                {
                    //Check if the player has a high score
                    //Перевірка, чи гравець попаде у список найкращих
                    if (score > p.score)
                    {
                        EnterName enter = new EnterName();
                        if (enter.ShowDialog() == DialogResult.OK)
                        {
                            string name = enter.playerName.Text;
                            Player player = new Player();
                            player.name = name;
                            player.score = score;
                            player.lines = lines;
                            player.level = level;
                            player.gameType = "Tetromino";
                            //Add player to high scores
                            //Додавання гравця до списку найкращих
                            hs.Add(player);
                            //Show highscores
                            //Показ інформації про кращих гравців
                            hs.Show();
                        }
                        break;
                    }
                }
            }
            else
            {
                HighScores hs = new HighScores("pento");
                var selectedPlayers = from p in hs.highScoresList
                                      where p.gameType == "Pentomino"
                                      select p;
                foreach (Player p in selectedPlayers)
                {
                    if (score > p.score)
                    {
                        EnterName enter = new EnterName();
                        if (enter.ShowDialog() == DialogResult.OK)
                        {
                            string name = enter.playerName.Text;
                            Player player = new Player();
                            player.name = name;
                            player.score = score;
                            player.lines = lines;
                            player.level = level;
                            player.gameType = "Pentomino";
                            hs.Add(player);
                            hs.Show();
                        }
                        break;
                    }
                }
            }
        }
        //'Highscores' menu
        //Меню "Кращі гравці"
        private void highToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!gameStarted)
            {
                if (tetroMenu.Checked)
                {
                    HighScores hs = new HighScores("tetro");
                    hs.Show();
                }
                else
                {
                    HighScores hs = new HighScores("pento");
                    hs.Show();
                }
            }
        }
        //'Settings' menu
        //Меню "Налаштування"
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!gameStarted)
            {
                SettingsForm sf = new SettingsForm(this);
                sf.Show();
            }
        }
        //'(Game) Mode' menu
        //Меню "Режим гри"
        private void tetrominoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Uncheck other menu options in this menu
            //При натисканні скидається прапорець у інших пунктів
            Uncheck((ToolStripMenuItem)sender);
        }
        //'(Game) Mode' menu
        //Меню "Режим гри"
        private void pentominoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Uncheck other menu options in this menu
            //При натисканні скидається прапорець у інших пунктів
            Uncheck((ToolStripMenuItem)sender);
        }
        //If you choose a game mode, other modes are unselected (StackOverflow)
        //Якщо обрати один режим гри у меню, то інші режими вимикаються (StackOverflow)
        private void Uncheck(ToolStripMenuItem selectedMenuItem)
        {
            selectedMenuItem.Checked = true;

            // Select the other MenuItens from the ParentMenu(OwnerItens) and unchecked this,
            // The current Linq Expression verify if the item is a real ToolStripMenuItem
            // and if the item is a another ToolStripMenuItem to uncheck this.
            foreach (var ltoolStripMenuItem in (from object
                                                    item in selectedMenuItem.Owner.Items
                                                let ltoolStripMenuItem = item as ToolStripMenuItem
                                                where ltoolStripMenuItem != null
                                                where !item.Equals(selectedMenuItem)
                                                select ltoolStripMenuItem))
                (ltoolStripMenuItem).Checked = false;

            // This line is optional, for show the mainMenu after click
            //selectedMenuItem.Owner.Show();
        }
    }
}