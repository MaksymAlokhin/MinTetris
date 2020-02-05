using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace MinTetris
{
    //Create and show the list of best players (highscores)
    //Клас для створення і показу списку кращих гарвців
    public partial class HighScores : Form
    {
        string type;
        //Top players list. 10 players from Tetromino and 10 from Pentomino
        //список кращих гравців, в нього входять 10 гравців у Tetromino та 10 гравців у Pentomino
        public List<Player> highScoresList;
        //Path to highscores file
        //шлях до файлу збереження кращих гравців
        public String path = Environment.CurrentDirectory + @"\Scores.dat";
        public HighScores(string type)
        {
            InitializeComponent();
            this.type = type;
            //If there is no file with best players, create one
            //Якщо немає файлу з найкращими гравцями, то створити
            if (!File.Exists(path))
            {
                Reset();
            }
            else
            {
                Serializer load = new Serializer();
                highScoresList = load.Deserialize(path) as List<Player>;
            }
            //Fill the display window with records
            //заповнити вікно записами
            FillListView();
        }
        //Adding new player to the highscores list, saving the file and displaying the list on the screen
        //Додавання нового гравця у таблицю рекордів, збереження даних у файл та показ таблиці на екрані
        public void Add(Player p)
        {
            highScoresList.Remove(highScoresList.Min());
            highScoresList.Add(p);
            highScoresList.Sort();
            highScoresList.Reverse();
            Serializer save = new Serializer();
            save.Serialize(path, highScoresList);
            FillListView();
        }
        //Generate the default list
        //Генерація списку за замовчуванням
        private void Reset()
        {
            Player p = new Player();
            highScoresList = p.DefaultList();
            Serializer save = new Serializer();
            save.Serialize(path, highScoresList);
        }
        //Display the highscores
        //Вивід даних про кращих гравців у вікно програми
        private void FillListView()
        {
            HighScoresListView.Items.Clear();
            foreach (Player player in highScoresList)
            {
                switch (type)
                {
                    case "tetro":
                        if (player.gameType == "Tetromino")
                        {
                            ListViewItem item = new ListViewItem(player.name);
                            item.SubItems.Add(player.score.ToString());
                            item.SubItems.Add(player.lines.ToString());
                            item.SubItems.Add(player.level.ToString());
                            HighScoresListView.Items.Add(item);
                        }
                        break;
                    case "pento":
                        if (player.gameType == "Pentomino")
                        {
                            ListViewItem item = new ListViewItem(player.name);
                            item.SubItems.Add(player.score.ToString());
                            item.SubItems.Add(player.lines.ToString());
                            item.SubItems.Add(player.level.ToString());
                            HighScoresListView.Items.Add(item);
                        }
                        break;
                }
            }
        }
        //'OK' button to close the window
        //Клавіша "ОК", закриття вікна
        private void okBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //'Reset' button, generate default list
        //Клавіша "Очистити список", генерація списку за замовчуванням
        private void resetBtn_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure?", "Reset", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (dr != DialogResult.Yes) return;
            Reset();
            FillListView();
        }
        //When the form loads, the active element is 'OK' button
        //При завантаженні вікна, активною стає кнопка "ОК"
        private void HighScores_Load(object sender, EventArgs e)
        {
            this.ActiveControl = okBtn;
        }
    }
}

