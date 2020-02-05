using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinTetris
{
    //Class Player is used to create top players list
    //Клас "Гравець". Використовується для створення списку кращих гравців
    [Serializable]
    public class Player : IComparable <Player>
    {
        public Player()
        {
            name = "Player";
            score = 0;
            lines = 0;
            level = 0;
        }
        public string name { get; set; }
        public int score { get; set; }
        public int lines { get; set; }
        public int level { get; set; }
        public string gameType { get; set; }
        //Compare two players by score
        //Метод для порівняння двох гравців за їхніми очками
        public int CompareTo (Player other)
        {
            return score.CompareTo(other.score);
        }
        //Create Default Top List       
        //Створення списку за замовчуванням
        public List<Player> DefaultList()
        {
            List<Player> list = new List<Player>();
            for (int lines = 10; lines <=100; lines+=10)
            {
                Player player = new Player();
                player.lines = lines;
                player.score = lines * 100;
                player.level = lines / 10;
                player.name = "Player " + (11-player.level).ToString();
                player.gameType = "Tetromino";
                list.Add(player);
            }
            for (int lines = 1; lines <= 10; lines ++)
            {
                Player player = new Player();
                player.lines = lines;
                player.score = lines * 100;
                player.level = lines / 10;
                player.name = "Player " + (11 - player.lines).ToString();
                player.gameType = "Pentomino";
                list.Add(player);
            }
            list.Sort();
            list.Reverse();
            return list;
        }
    }
}
