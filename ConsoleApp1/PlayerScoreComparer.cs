using System.Collections.Generic;

namespace ConsoleApp1
{
    internal class PlayerScoreComparer : IComparer<Player>
    {
        public int Compare(Player x, Player y)
        {
            return x.Score.CompareTo(y.Score);
        }
    }
}