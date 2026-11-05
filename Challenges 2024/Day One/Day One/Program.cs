using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Day_One
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

        static int partOne(string[]left, string[]right)
        {
            int result = 0;
            Array.Sort(left);
            Array.Sort(right);
            for (int i = 0; i < left.Length; i++)
            {
                result += Math.Abs(int.Parse(left[i]) - int.Parse(right[i]));
            }
            return result;
        }

        static int partTwo(string[]left, string[]right)
        {
            int total = 0;
            for (int i = 0; i < left.Length; i++)
            {
                int count = 0;

                for (int j = 0; j < right.Length; j++)
                {
                    if (left[i] == right[j])
                    {
                        count++;
                    }
                }
                total += (int.Parse(left[i]) * count);
            }
            return total;
        }

        static void Main(string[] args)
        {
            List<string> inputData = getData();
            string[] left = new string[inputData.Count];
            string[] right = new string[inputData.Count];
            for (int i = 0; i < inputData.Count; i++)
            {
                string[] temp = inputData[i].Split(' ');
                left[i] = temp[0];
                right[i] = temp[3];
            }
            Console.WriteLine(partOne(left, right));
            Console.WriteLine(partTwo(left, right));
            Console.ReadLine();
        }
    }
}
