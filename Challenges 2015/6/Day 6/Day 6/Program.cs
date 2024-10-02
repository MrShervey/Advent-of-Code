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
        static string[] splitCommands(string data)
        {
            string[] instructions = data.Split(' ');
            string[] commands = new string[3];
            if (instructions.Length == 5)
            {
                commands[0] = instructions[0] + " " + instructions[1];
                commands[1] = instructions[2];
                commands[2] = instructions[4];
            }
            else
            {
                commands[0] = instructions[0];
                commands[1] = instructions[1];
                commands[2] = instructions[3];
            }
            return commands;
        }
        static int partOne(List<string> data)
        {
            bool[,] lights = new bool[1000, 1000];
            string[] commands = new string[3];
            int x1, x2, y1, y2;
            int count = 0;
            for (int i = 0; i < data.Count; i++)
            {
                commands = splitCommands(data[i]);
                x1 = Convert.ToInt32(commands[1].Split(',')[0]);
                y1 = Convert.ToInt32(commands[1].Split(',')[1]);
                x2 = Convert.ToInt32(commands[2].Split(',')[0]);
                y2 = Convert.ToInt32(commands[2].Split(',')[1]);
                for (int j = x1; j <= x2; j++)
                { 
                    for (int k = y1; k <= y2; k++)
                    {
                        if (commands[0] == "turn off")
                        {
                            lights[j,k] = false;
                        }
                        else if (commands[0] == "turn on")
                        {
                            lights[j,k] = true;
                        }
                        else if (commands[0] == "toggle")
                        {
                            if (!lights[j, k])
                            {
                                lights[j, k] = true;
                            }
                            else
                            {
                                lights[j, k] = false;
                            }
                        }
                    }
                }
            }
            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    if (lights[i,j])
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        static int partTwo(List<string> data)
        {
            int[,] lights = new int[1000, 1000];
            string[] commands = new string[3];
            int x1, x2, y1, y2;
            int count = 0;
            for (int i = 0; i < data.Count; i++)
            {
                commands = splitCommands(data[i]);
                x1 = Convert.ToInt32(commands[1].Split(',')[0]);
                y1 = Convert.ToInt32(commands[1].Split(',')[1]);
                x2 = Convert.ToInt32(commands[2].Split(',')[0]);
                y2 = Convert.ToInt32(commands[2].Split(',')[1]);
                for (int j = x1; j <= x2; j++)
                {
                    for (int k = y1; k <= y2; k++)
                    {
                        if (commands[0] == "turn off")
                        {
                            if (lights[j,k] > 0)
                            {
                                lights[j, k]--;
                            }
                            
                        }
                        else if (commands[0] == "turn on")
                        {
                            lights[j, k]++;
                        }
                        else if (commands[0] == "toggle")
                        {
                            
                            lights[j, k] = lights[j,k] + 2;
                            
                        }
                    }
                }
            }
            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    count = count + lights[i,j];
                    
                }
            }
            return count;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(partOne(getData()));
            Console.WriteLine(partTwo(getData()));
            Console.ReadLine();
        }
    }
}
