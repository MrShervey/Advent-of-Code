using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_6
{
    internal class Program
    {
        static List<string> getData()
        {
            List<string> inputData = new List<string>();
            TextReader textFile = new StreamReader("inputData.txt");
            string data;
            while ((data = textFile.ReadLine()) != null)
            {
                inputData.Add(data);
            }
            textFile.Close();
            return inputData;
        }

        static void solution(string[,] grid, int rows, int cols)
        {
            int partOne = 0;
            bool inBounds = true;
            string direction = "n";
            int x = 0, y = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    switch (grid[i, j])
                    {
                        case "<":
                            {
                                direction = "w";
                                x = i;
                                y = j;
                                break;
                            }
                        case ">":
                            {
                                direction = "e";
                                x = i;
                                y = j;
                                break;
                            }

                        case "^":
                            {
                                direction = "n";
                                x = i;
                                y = j;
                                break;
                            }
                        case "v":
                            {
                                direction = "s";
                                x = i;
                                y = j;
                                break;
                            }
                    }
                }
            }
            while (inBounds)
            {
                grid[x, y] = "x";
                try
                {
                    if (direction == "n")
                    {
                        if (grid[x - 1, y] == "#")
                        {
                            direction = "e";
                        }
                        else
                        {
                            x = x - 1;
                        }
                    }
                    else if (direction == "e")
                    {
                        if (grid[x, y + 1] == "#")
                        {
                            direction = "s";
                        }
                        else
                        {
                            y = y + 1;
                        }
                    }
                    else if (direction == "s")
                    {
                        if (grid[x + 1, y] == "#")
                        {
                            direction = "w";
                        }
                        else
                        {
                            x = x + 1;
                        }
                    }
                    else if (direction == "w")
                    {
                        if (grid[x, y - 1] == "#")
                        {
                            direction = "n";
                        }
                        else
                        {
                            y = y - 1;
                        }
                    }
                }
                catch (Exception e)
                {
                    inBounds = false;
                }
            }
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (grid[i,j] == "x")
                    {
                        partOne++;
                    }
                }
            }
            Console.WriteLine("Part One: {0}", partOne);
        }

        static void Main(string[] args)
        {
            List<string> inputData = getData();
            int rows = inputData.Count;
            int cols = inputData[0].Length;
            string[,]grid = new string[rows,cols];
            for (int i = 0; i < inputData.Count; i++)
            {
                for (int j = 0; j < inputData[i].Length; j++)
                {
                    grid[i,j] = inputData[i].Substring(j,1);
                }
            }
            solution(grid, rows, cols);
        }
    }
}
