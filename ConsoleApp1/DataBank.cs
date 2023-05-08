using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1
{
    internal class DataBank
    {
        public static void WriteToFile(Player player)
        {
            using (StreamWriter writer = new StreamWriter("players.txt", true))
            {
                writer.WriteLine(player.Name + " " + player.Score);
            }
        }

        public static List<Player> ReadFromFile()
        {
            List<Player> players = new List<Player>();
            using (StreamReader reader = new StreamReader("players.txt"))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] parts = line.Split(' ');
                    Player player = new Player(parts[0]);
                    int number;
                    try
                    {
                        if(int.TryParse(parts[1], out number))
                        {
                            player.Score = number;
                        }
                        else
                        {
                            player.Score = 0;
                            throw new Exception("Wrong format");
                        }
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine($"{e.Message}");
                    }
                    players.Add(player);
                }
            }
            return players;
        }
    }
}