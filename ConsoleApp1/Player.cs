using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Player
    {
        private int score;
        private string name;

        public Player(string name)
        {
            Name = name;
            score = 0;
        }


        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                this.name = value;
            }
        }
        public int Score
        {
            get
            {
                return score;
            }

            set
            {
                score = value;
            }
        }

        public void addScore()
        {
            score += 10;
        }
    }
}
