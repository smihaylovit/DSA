using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthNS
{
    public class LabyrinthMain
    {
        static void Main()
        {
            string[,] labyrinth = {
                                      {"0", "0", "0", "x", "0", "x"},
                                      {"0", "x", "0", "x", "0", "x"},
                                      {"0", "*", "x", "0", "x", "0"},
                                      {"0", "x", "0", "0", "0", "0"},
                                      {"0", "0", "0", "x", "x", "0"},
                                      {"0", "0", "0", "x", "0", "x"},
                                  };
            Console.WriteLine(PrintLabyrinth(labyrinth));
            string[,] solvedLabyrinth = SolveLabyrinth(labyrinth);
            Console.WriteLine();
            Console.WriteLine(PrintLabyrinth(solvedLabyrinth));
        }

        private static string[,] SolveLabyrinth(string[,] labyrinth)
        {
            int startX = 0;
            int startY = 0;

            if (GetStartingPoint(labyrinth, out startX, out startY))
            {
                Queue<LabyrinthElement> queue = new Queue<LabyrinthElement>();
                labyrinth[startX, startY] = "0";
                LabyrinthElement element = new LabyrinthElement(startX, startY, int.Parse(labyrinth[startX, startY]));
                queue.Enqueue(element);

                while (queue.Count > 0)
                {
                    LabyrinthElement newElement = new LabyrinthElement(queue.Dequeue());
                    labyrinth[newElement.X, newElement.Y] = newElement.Value.ToString();
                    newElement.Value++;

                    if (((newElement.X - 1) >= 0) &&
                        (labyrinth[newElement.X - 1, newElement.Y] == "0"))
                    {
                        LabyrinthElement firstElement = new LabyrinthElement(newElement.X - 1, newElement.Y, newElement.Value);
                        queue.Enqueue(firstElement);
                    }
                    if ((newElement.X + 1 < labyrinth.GetLength(0)) &&
                        (labyrinth[newElement.X + 1, newElement.Y] == "0"))
                    {
                        LabyrinthElement secondElement = new LabyrinthElement(newElement.X + 1, newElement.Y, newElement.Value);
                        queue.Enqueue(secondElement);
                    }
                    if ((newElement.Y - 1 >= 0) &&
                        (labyrinth[newElement.X, newElement.Y - 1] == "0"))
                    {
                        LabyrinthElement thirdElement = new LabyrinthElement(newElement.X, newElement.Y - 1, newElement.Value);
                        queue.Enqueue(thirdElement);
                    }
                    if ((newElement.Y + 1 < labyrinth.GetLength(1)) &&
                        (labyrinth[newElement.X, newElement.Y + 1] == "0"))
                    {
                        LabyrinthElement fourthElement = new LabyrinthElement(newElement.X, newElement.Y + 1, newElement.Value);
                        queue.Enqueue(fourthElement);
                    }
                }
                labyrinth[startX, startY] = "*";

                FindUnreachableCells(labyrinth);
            }
            else
            {
                throw new ArgumentException("No entry point");
            }

            return labyrinth;
        }


        private static bool GetStartingPoint(string[,] labyrinth, out int startX, out int startY)
        {
            startX = 0;
            startY = 0;

            for (int row = 0; row < labyrinth.GetLength(0); row++)
            {
                for (int col = 0; col < labyrinth.GetLength(1); col++)
                {
                    if (labyrinth[row, col] == "*")
                    {
                        startX = row;
                        startY = col;
                        return true;
                    }
                }
            }

            return false;
        }

        private static void FindUnreachableCells(string[,] labyrinth)
        {
            for (int row = 0; row < labyrinth.GetLength(0); row++)
            {
                for (int col = 0; col < labyrinth.GetLength(1); col++)
                {
                    if (labyrinth[row, col] == "0")
                    {
                        labyrinth[row, col] = "u";
                    }
                }
            }
        }

        private static string PrintLabyrinth(string[,] labyrinth)
        {
            int rows = labyrinth.GetLength(0);
            int cols = labyrinth.GetLength(1);
            StringBuilder result = new StringBuilder();

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    result.Append(labyrinth[row, col]);
                    result.Append(" ");
                }
                result.Append("\n\r");
            }

            return result.ToString();
        }
    }
}