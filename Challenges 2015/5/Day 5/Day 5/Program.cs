using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_5
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

        static bool partOne(string data)
        {
            bool result = false;
            string vowels = "aeiou";
            int vowelCount = 0;
            bool doubleLetter = false;
            for (int i = 0; i < data.Length; i++)
            {
                if (vowels.Contains(data[i]))
                {
                    vowelCount++;
                }
            }
            if (vowelCount >= 3)
            {
                for (int i = 0; i < data.Length-1; i++)
                {
                    if (data[i] == data[i+1])
                    {
                        doubleLetter = true;
                    }
                }
            }
            if (doubleLetter)
            {
                if (!data.Contains("ab") && !data.Contains("cd") && !data.Contains("pq") && !data.Contains("xy"))
                {
                    result = true;
                }
            }
            return result;
        }

        static bool partTwo(string data)
        {
            bool resultOne = false;
            bool resultTwo = false;
            string pair;
            for (int i = 0; i < data.Length - 1; i++)
            {
                pair = data.Substring(i, 2);
                if (data.Substring(i+2, data.Length-(i+2)).Contains(pair))
                {
                    resultOne = true;
                }
            }
            for (int i = 0;i < data.Length-2;i++)
            {
                if (data[i] == data[i+2])
                {
                    resultTwo = true;
                }
            }
            if (resultOne && resultTwo)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static void Main(string[] args)
        {
            var data = getData();
            int p1total = 0;
            int p2total = 0;
            for (int i = 0; i < data.Count; i++)
            {
                if (partOne(data[i]))
                {
                    p1total++;
                }
                if (partTwo(data[i]))
                {
                    p2total++;
                }
            }
            Console.WriteLine(p1total);
            Console.WriteLine(p2total);
            Console.ReadLine();
        }
    }
}
