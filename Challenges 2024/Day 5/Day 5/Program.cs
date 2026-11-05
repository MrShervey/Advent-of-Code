using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

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

        static int[] solution(List<string>instructions, List<string>pages)
        {
            int[] results = { 0, 0 };
            bool order;
            List<string> invalid = new List<string>();
            for (int i = 0; i < pages.Count; i++)
            {
                //Part One
                order = true;
                string[] values = pages[i].Split(',');
                for (int j = 0; j < instructions.Count; j++)
                {
                    string[] numbers = instructions[j].Split('|');
                    if (values.Contains(numbers[0]) && values.Contains(numbers[1]))
                    {
                        int indexA = Array.IndexOf(values, numbers[0]);
                        int indexB = Array.IndexOf(values, numbers[1]);
                        if (indexB < indexA)
                        {
                            order = false;
                        }
                    }
                }
                if (order)
                {
                    int mid = values.Length / 2;
                    results[0] += Convert.ToInt32(values[mid]);
                }
                else
                {
                    //Part Two
                    invalid.Add(pages[i]);
                    bool swapped = true;
                    while (swapped)
                    {
                        swapped = false;
                        for (int j = 0; j < instructions.Count; j++)
                        {
                            string[] numbers = instructions[j].Split('|');
                            if (values.Contains(numbers[0]) && values.Contains(numbers[1]))
                            {
                                int indexA = Array.IndexOf(values, numbers[0]);
                                int indexB = Array.IndexOf(values, numbers[1]);
                                if (indexB < indexA)
                                {
                                    string temp = values[indexB];
                                    values[indexB] = values[indexA];
                                    values[indexA] = temp;
                                    swapped = true;
                                }
                            }
                        }
                    }
                    int middle = values.Length / 2;
                    results[1] += Convert.ToInt32(values[middle]);
                }
            }
            return results;
        }

        static void Main(string[] args)
        {
            List<string> inputData = getData();
            List<string> insts = new List<string>();
            List<string> data = new List<string>();
            bool first = true;
            for (int i = 0; i < inputData.Count; i++)
            {
               if (inputData[i] == "")
                {
                    first = false;
                }
                if (first)
                {
                    insts.Add(inputData[i]);
                }
                else
                {
                    data.Add(inputData[i]);
                }
            }
            data.Remove("");
            int[] answers = solution(insts, data);
            Console.WriteLine("Part One: {0}", answers[0]);
            Console.WriteLine("Part Two: {0}", answers[1]);
            Console.ReadLine();
        }
    }
}