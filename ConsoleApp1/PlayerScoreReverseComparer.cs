using System.Collections.Generic;

namespace ConsoleApp1
{
    internal class PlayerScoreReverseComparer : IComparer<Player>
    {
        public int Compare(Player x, Player y)
        {
            return y.Score.CompareTo(x.Score);
        }
    }
}