using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Game
    {
        private Board board;
        private bool gameOver;
        private Random random;
        private Shape currentShape;
        private Player player;

        public Game(int height, int width)
        {
            Board = new Board(height, width);
            Random = new Random();
            currentShape = new Shape(0, 0, null);
            GameOver = false;
            player = new Player("");
        }

        public Board Board
        {
            get
            {
                return this.board;
            }
            set
            {
                this.board = value;
            }
        }

        public Player Player
        {
            set
            {
                this.player = value;
            }
            get
            {
                return this.player;
            }
        }

        public Shape CurrentShape
        {
            get
            {
                return this.currentShape;
            }
            set
            {
                this.currentShape = value;
            }
        }

        public bool GameOver
        {
            get
            {
                return this.gameOver;
            }
            set
            {
                this.gameOver = value;
            }
        }

        public Random Random
        {
            get
            {
                return this.random;
            }
            set
            {
                this.random = value;
            }
        }

        public void CreateFigure()
        {
            // фигуры
            int[,] shapeI = { { 1, 1, 1, 1 } };
            int[,] shapeO = { { 2, 2 }, { 2, 2 } };
            int[,] shapeT = { { 0, 3, 0 }, { 3, 3, 3 } };
            int[,] shapeS = { { 0, 4, 4 }, { 4, 4, 0 } };
            int[,] shapeZ = { { 5, 5, 0 }, { 0, 5, 5 } };
            int[,] shapeJ = { { 6, 0, 0 }, { 6, 6, 6 } };
            int[,] shapeL = { { 0, 0, 7 }, { 7, 7, 7 } };

            // создаем фигуру, если ее нет
            if (currentShape.CurrentShape == null)
            {
                int shapeIndex = random.Next(7);
                switch (shapeIndex)
                {
                    case 0:
                        currentShape = new Shape(0, 0, shapeI);
                        break;
                    case 1:
                        currentShape = new Shape(0, 0, shapeO);
                        break;
                    case 2:
                        currentShape = new Shape(0, 0, shapeT);
                        break;
                    case 3:
                        currentShape = new Shape(0, 0, shapeS);
                        break;
                    case 4:
                        currentShape = new Shape(0, 0, shapeZ);
                        break;
                    case 5:
                        currentShape = new Shape(0, 0, shapeJ);
                        break;
                    case 6:
                        currentShape = new Shape(0, 0, shapeL);
                        break;
                }
                currentShape.CurrentShapeRow = 0;
                currentShape.CurrentShapeCol = board.GetLength(1) / 2 - currentShape.GetLength(1) / 2;
            }
        }

        public void DrawBoard()
        {
            // отрисовка
            Console.Clear();
            Console.WriteLine("Score: " + Player.Score);
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    if (row >= currentShape.CurrentShapeRow && row < currentShape.CurrentShapeRow + currentShape.GetLength(0) &&
                        col >= currentShape.CurrentShapeCol && col < currentShape.CurrentShapeCol + currentShape.GetLength(1) &&
                        currentShape[row - currentShape.CurrentShapeRow, col - currentShape.CurrentShapeCol] != 0)
                    {
                        if(currentShape[row - currentShape.CurrentShapeRow, col - currentShape.CurrentShapeCol] == 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        else if (currentShape[row - currentShape.CurrentShapeRow, col - currentShape.CurrentShapeCol] == 2)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                        }
                        else if (currentShape[row - currentShape.CurrentShapeRow, col - currentShape.CurrentShapeCol] == 3)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                        }
                        else if (currentShape[row - currentShape.CurrentShapeRow, col - currentShape.CurrentShapeCol] == 4)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                        }
                        else if (currentShape[row - currentShape.CurrentShapeRow, col - currentShape.CurrentShapeCol] == 5)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        else if (currentShape[row - currentShape.CurrentShapeRow, col - currentShape.CurrentShapeCol] == 6)
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                        }
                        else if (currentShape[row - currentShape.CurrentShapeRow, col - currentShape.CurrentShapeCol] == 7)
                        {
                            Console.ForegroundColor = ConsoleColor.Magenta;
                        }
                        Console.Write(currentShape[row - currentShape.CurrentShapeRow, col - currentShape.CurrentShapeCol]);
                        Console.ResetColor();
                    }
                    else
                    {
                        if (board[row, col] == 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        else if (board[row, col] == 2)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                        }
                        else if (board[row, col] == 3)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                        }
                        else if (board[row, col] == 4)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                        }
                        else if (board[row, col] == 5)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        else if (board[row, col] == 6)
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                        }
                        else if (board[row, col] == 7)
                        {
                            Console.ForegroundColor = ConsoleColor.Magenta;
                        }
                        Console.Write(board[row, col]);
                        Console.ResetColor();
                    }
                }
                Console.WriteLine();
            }
        }

        public void MoveDown()
        {
            // перемещение фигуры вниз
            System.Threading.Thread.Sleep(1000); // пауза секунда
            if (currentShape.CurrentShapeRow + currentShape.GetLength(0) == board.GetLength(0))
            {
                // если фигура достигла дна
                for (int row = 0; row < currentShape.GetLength(0); row++)
                {
                    for (int col = 0; col < currentShape.GetLength(1); col++)
                    {
                        if (currentShape[row, col] != 0)
                        {
                            board[currentShape.CurrentShapeRow + row, currentShape.CurrentShapeCol + col] = currentShape[row, col];
                        }
                    }
                }
                currentShape.CurrentShape = null;
            }
            else
            {
                for (int col = 0; col < currentShape.GetLength(1); col++)
                {
                    int newCol = currentShape.CurrentShapeCol + col;
                    if (currentShape.CurrentShapeRow + 1 >= board.Height || board[currentShape.CurrentShapeRow + 1, newCol] != 0)
                    {
                        // если фигура наткнулась на другую
                        for (int row = 0; row < currentShape.GetLength(0); row++)
                        {
                            for (int col1 = 0; col1 < currentShape.GetLength(1); col1++)
                            {
                                if (currentShape[row, col1] != 0)
                                {
                                    board[currentShape.CurrentShapeRow + row, currentShape.CurrentShapeCol + col1] = currentShape[row, col1];
                                }
                            }
                        }
                        currentShape.CurrentShape = null;
                        break;
                    }
                }
                // перемещенее текущей фигуры вниз
                currentShape.CurrentShapeRow++;
            }
        }

        public void ErraseFull()
        {
            // проверка строк
            for (int row = board.GetLength(0) - 1; row >= 0; row--)
            {
                if (board.IsRowComplete(row))
                {
                    // удаляем заполненые строки
                    board.clearRow(row);
                    Player.addScore();
                    row++;
                }
            }
        }

        public void EndGame()
        {
            // проверка на завершение игры
            for (int col = 0; col < board.GetLength(1); col++)
            {
                if (board[0, col] != 0)
                {
                    gameOver = true;
                    break;
                }
            }
        }

        public void HandleAction()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.LeftArrow && currentShape.CurrentShapeCol > 0)
                {
                    currentShape.CurrentShapeCol--;
                }
                else if (key.Key == ConsoleKey.RightArrow && currentShape.CurrentShapeCol + currentShape.GetLength(1) < board.GetLength(1))
                {
                    currentShape.CurrentShapeCol++;
                }
                else if(key.Key == ConsoleKey.Spacebar)
                {
                    GameOver = true;
                }
            }
        }

        public void InitializePlayer()
        {
            while(player.Name.Length == 0 || player.Name == null)
            {
                Console.WriteLine("Enter your name: ");
                player.Name = Console.ReadLine();
            }
            Console.WriteLine($"{player.Name}, welcome to tetris game!");
            Console.ReadKey();
            Console.Clear();
        }

        public void AddPlayerToList()
        {
            DataBank.WriteToFile(player);
        }

        public void ShowTopPlayers()
        {
            List<Player> players = DataBank.ReadFromFile();
            players.Sort(new PlayerScoreReverseComparer());
            Console.WriteLine("Top players: ");
            foreach(Player player in players)
            {
                Console.WriteLine($"{player.Name} - {player.Score}");
            }
        }

        public void ShowRules()
        {
            Console.Clear();
            Console.WriteLine("Правила" +
                "\n1 - Для перемещения используем правую и левую стрелки" +
                "\n2 - При заполнении рядка он пропадает" +
                "\n3 - За каждый рядок начисляется 10 баллов" +
                "\n4 - Победитель тот, кто набрал больше всего баллов" +
                "\nПриятной игры)");
            Console.ReadKey();
            Console.Clear();
        }
    }
}