using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_4
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

        static int partOne(string[,] grid,int len, int lines)
        {
            int count = 0;
            
            for (int x = 0; x < lines; x++)
            {
                for (int y = 0; y < len; y++)
                {
                    if (grid[x,y] == "X")
                    {
                        if (y+3 < len)
                        {
                            if (grid[x,y+1] == "M" && grid[x,y+2] == "A" && grid[x,y+3] == "S")
                            {
                                count++;
                            }
                        }
                        if (y-3 >= 0)
                        {
                            if (grid[x, y-1] == "M" && grid[x, y-2] == "A" && grid[x, y-3] == "S")
                            {
                                count++;
                            }
                        }
                        if (x+3 < lines)
                        {
                            if (grid[x+1, y] == "M" && grid[x+2,y] == "A" && grid[x+3, y] == "S")
                            {
                                count++;
                            }
                        }
                        if (x-3  >= 0)
                        {
                            if (grid[x-1, y] == "M" && grid[x-2, y] == "A" && grid[x-3, y] == "S")
                            {
                                count++;
                            }
                        }
                        if (y+3<len && x-3>=0)
                        {
                            if (grid[x-1, y+1] == "M" && grid[x - 2, y+2] == "A" && grid[x - 3, y+3] == "S")
                            {
                                count++;
                            }
                        }
                        if (y + 3 < len && x + 3 < lines)
                        {
                            if (grid[x + 1, y + 1] == "M" && grid[x + 2, y + 2] == "A" && grid[x + 3, y + 3] == "S")
                            {
                                count++;
                            }
                        }
                        if (y - 3 >= 0 && x - 3 >= 0)
                        {
                            if (grid[x - 1, y - 1] == "M" && grid[x - 2, y - 2] == "A" && grid[x - 3, y - 3] == "S")
                            {
                                count++;
                            }
                        }
                        if (y - 3 >= 0 && x + 3 < lines)
                        {
                            if (grid[x + 1, y - 1] == "M" && grid[x + 2, y - 2] == "A" && grid[x + 3, y - 3] == "S")
                            {
                                count++;
                            }
                        }
                    }
                }
            }
            return count;
        }
        static int partTwo(string[,] grid, int len, int lines)
        {
            int count = 0;

            for (int x = 0; x < lines; x++)
            {
                for (int y = 0; y < len; y++)
                {
                    if (grid[x, y] == "A")
                    {
                        if (x > 0 && x < lines - 1 && y > 0 & y < len - 1)
                        {
                            if ((grid[x - 1, y - 1] == "M" && grid[x + 1, y + 1] == "S") || (grid[x - 1, y - 1] == "S" && grid[x + 1, y + 1] == "M"))
                            {
                                if ((grid[x + 1, y - 1] == "M" && grid[x - 1, y + 1] == "S") || (grid[x + 1, y - 1] == "S" && grid[x - 1, y + 1] == "M"))
                                {
                                count++;
                                }
                            }
                        }
                    }
                }
            }
            return count;
        }
        static void Main(string[] args)
        { 
            List<string> inputData = getData();
            int len = inputData[0].Length;
            int lines = inputData.Count;
            string[,] grid = new string[inputData[0].Length, inputData.Count];
            for (int i = 0; i < inputData.Count; i++)
            {
                string line = inputData[i];
                for (int j = 0; j < inputData[i].Length; j++)
                {
                    grid[i,j] = line.Substring(j,1);
                }
            }
            Console.WriteLine("Part One: {0}", partOne(grid,len,lines));
            Console.WriteLine("Part Two: {0}", partTwo(grid, len, lines));
            Console.ReadLine();

        }
    }
}
