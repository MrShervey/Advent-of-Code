using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Day_Two
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

        static bool checkSafe(string[] values)
        {
            int count = 0, total = 0;

            if (Convert.ToInt32(values[0]) < Convert.ToInt32(values[1]))
            {
                while (count < values.Length - 1 && Convert.ToInt32(values[count]) < Convert.ToInt32(values[count + 1]) && Math.Abs(Convert.ToInt32(values[count]) - Convert.ToInt32(values[count + 1])) < 4)
                {
                    count++;
                }
            }
            else if (Convert.ToInt32(values[0]) > Convert.ToInt32(values[1]))
            {
                while (count < values.Length - 1 && Convert.ToInt32(values[count]) > Convert.ToInt32(values[count + 1]) && Math.Abs(Convert.ToInt32(values[count]) - Convert.ToInt32(values[count + 1])) < 4)
                {
                    count++;
                }
            }
            if (count == values.Length - 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static int partOne(List<string> data)
        {
            int total = 0;
            string[] values;
            for (int i = 0; i < data.Count; i++)
            {
                values = data[i].Split(' ');
                if (checkSafe(values))
                {
                    total++;
                }
            }
            return total;
        }

        static int partTwo(List<string> data)
        {
            string[] sValues;
            
            int total = 0;
            for (int i = 0; i < data.Count; i++)
            {
                sValues = data[i].Split(' ');
                int[] values = new int[sValues.Length];
                for (int x = 0; x < sValues.Length; x++)
                {
                    values[x] = int.Parse(sValues[x]);
                }
                if (checkSafe(sValues))
                {
                    total++;
                }
                else
                {
                    for (int j = 0; j < sValues.Length; j++)
                    {
                        var temp = sValues.ToArray();
                        for (int t = j; t < temp.Length - 1; t++)
                        {
                            temp[t] = temp[t + 1];
                        }
                        Array.Resize(ref temp, temp.Length - 1);
                        if (checkSafe(temp))
                        {
                            total++;
                            break;
                        }  
                    }
                }
            }
            return total;
        }
        
        static void Main(string[] args)
        {
            List<string> inputData = getData();
            Console.WriteLine("Part One: {0}", partOne(inputData));
            Console.WriteLine("Part Two: {0}", partTwo(inputData));
            Console.ReadLine();
        }
    }
}
