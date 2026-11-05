using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day_3
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

        static List<string> getValues(List<string> data)
        {
            List<string>values = new List<string>();
            bool allowed = true;
            var regex = new Regex(@"mul\(\d+,\d+\)");
            var dos = new Regex(@"do\(\)");
            var donts = new Regex(@"don't\(\)");
            foreach (string v in data)
            {
                var matches = regex.Matches(v);
                foreach (Match m in matches)
                { 
                    if(donts.IsMatch(v.Substring(0, m.Index)))
                    {
                        allowed = false;
                    }
                    if (dos.IsMatch(v.Substring(0, m.Index)))
                    {
                        allowed = true;
                    }
                    if (allowed)
                    {
                        string str = m.Value;
                        str = str.Replace("mul(", string.Empty);
                        str = str.Replace(")", string.Empty);
                        values.Add(str);
                    }
                }
            }
            return values;
        }

        static int partOne(List<string> data)
        {
            int result = 0;
            string[] nums = new string[2];
            for (int i = 0; i < data.Count; i++)
            {
                nums = data[i].Split(',');
                result += (int.Parse(nums[0]) * int.Parse(nums[1]));
            }
            return result;
        }

        static void Main(string[] args)
        {
            List<string> inputData = getData();
            Console.WriteLine(partOne(getValues(inputData)));
            Console.ReadLine();
        }
    }
}
