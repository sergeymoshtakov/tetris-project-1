using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Board
    {
        private int[,] board;
        private int width;
        private int height;

        public Board(int height, int width)
        {
            Width = width;
            Height = height;
            board = new int[height, width];
        }

        public int Width
        {
            set
            {
                this.width = value;
            }
            get
            {
                return width;
            }
        }

        public int Height
        {
            set
            {
                this.height = value;
            }
            get
            {
                return height;
            }
        }

        public int this[int row, int col]
        {
            get
            {
                try
                {
                    if (row < 0 || row >= height || col < 0 || col >= width)
                    {
                        throw new Exception("Wrong parameters");
                    }
                    else
                    {
                        return board[row, col];
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine($"{e.Message}");
                    return 0;
                }
            }
            set
            {
                try
                {
                    if (row < 0 || row >= height || col < 0 || col >= width)
                    {
                        throw new Exception("Wrong parameters");
                    }
                    else
                    {
                        board[row, col] = value;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"{e.Message}");
                }
            }
        }

        public int GetLength(int dimension)
        {
            if(dimension == 0)
            {
                return height;
            }
            else if(dimension == 1)
            {
                return width;
            }
            else
            {
                throw new Exception("Wrong value for dimension");
            }
        }

        public bool IsRowComplete(int row)
        {
            for (int col = 0; col < width; col++)
            {
                if (board[row, col] == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public void clearRow(int row)
        {
            for (int r = row; r > 0; r--)
            {
                for (int c = 0; c < width; c++)
                {
                    board[r, c] = board[r - 1, c];
                }
            }
        }
    }
}
