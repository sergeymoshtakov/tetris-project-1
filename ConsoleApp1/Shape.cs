using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Shape
    {
        private int[,] currentShape;
        private int currentShapeRow;
        private int currentShapeCol;

        public Shape(int currentShapeRow, int currentShapeCol, int[,] currentShape)
        {
            CurrentShapeRow = currentShapeRow;
            CurrentShapeCol = currentShapeCol;
            CurrentShape = currentShape;
        }

        public int CurrentShapeRow
        {
            get
            {
                return currentShapeRow;
            }
            set 
            {
                this.currentShapeRow = value;
            }
        }

        public int CurrentShapeCol
        {
            get
            {
                return currentShapeCol;
            }
            set
            {
                this.currentShapeCol = value;
            }
        }

        public int [,] CurrentShape
        {
            get
            {
                return currentShape;
            }
            set
            {
                this.currentShape = value;
            }
        }

        public int GetLength(int dimension)
        {
            try
            {
                if (currentShape == null)
                {
                    throw new Exception("thisShape is null");
                }
                else
                {
                    try
                    {
                        if (dimension == 0)
                        {
                            return currentShape.GetLength(0);
                        }
                        else if (dimension == 1)
                        {
                            return currentShape.GetLength(1);
                        }
                        else
                        {
                            throw new Exception("Wrong value for dimension");
                        }
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine($"{e.Message}");
                        return 0;
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine($"{e.Message}");
                return 0;
            }
        }

        public int this[int row, int col]
        {
            get
            {
                try
                {
                    if (row < 0 || row >= currentShape.GetLength(0) || col < 0 || col >= currentShape.GetLength(1))
                    {
                        throw new Exception("Wrong parameters");
                    }
                    else
                    {
                        return currentShape[row, col];
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"{e.Message}");
                    return 0;
                }
            }
            set
            {
                try
                {
                    if (row < 0 || row >= currentShape.GetLength(0) || col < 0 || col >= currentShape.GetLength(1))
                    {
                        throw new Exception("Wrong parameters");
                    }
                    else
                    {
                        currentShape[row, col] = value;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"{e.Message}");
                }
            }
        }
    }
}