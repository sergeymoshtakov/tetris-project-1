using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Tetris game";
            Game game = new Game(20, 10);
            int answ = 0;
            while(answ != 2)
            {
                Console.WriteLine("Выберете:\n1 - Начать новую игруe\n2 - Выход");
                answ = Convert.ToInt32(Console.ReadLine());
                switch(answ)
                {
                    case 1:
                        Console.Clear();
                        game.InitializePlayer();
                        game.ShowRules();
                        game.GameOver = false;
                        // сама игра
                        while (!game.GameOver)
                        {
                            game.CreateFigure(); // создаем фигуры
                            game.DrawBoard(); // отрисовываем экран
                            game.MoveDown(); // перемещаем фигуры вниз
                            game.ErraseFull(); // стираем заполненые строки
                            game.EndGame(); // конец игры
                            game.HandleAction(); // перемещаем в лево и в право
                        }

                        // завершаем игру
                        game.AddPlayerToList(); // добавляем игрока в банк
                        Console.Clear();
                        Console.WriteLine("Game over!");
                        Console.WriteLine("Score: " + game.Player.Score);
                        game.ShowTopPlayers(); // читаем список лучших игроков из банка
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 2:
                        Console.WriteLine("Good bye");
                        break;
                    default:
                        Console.WriteLine("Wrong input!");
                        break;
                }
            }
        }
    }
}