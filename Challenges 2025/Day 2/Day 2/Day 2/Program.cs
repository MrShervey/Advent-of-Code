using System;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
class Program
{
    static void Main(string[] args)
    {
        partOne();
        partTwo();
    }

    static void partOne()
    {
        string[] values;
        ulong first, last;
        string left, right;
        ulong total = 0;
        TextReader textFile = new StreamReader("inputData.txt");
        string data = textFile.ReadLine();
        string[] splitData = data.Split(',');
        for (int x = 0; x < splitData.Length; x++)
        {
            values = splitData[x].Split('-');
            first = Convert.ToUInt64(values[0]);
            last = Convert.ToUInt64(values[1]);
            for (ulong y = first; y <= last; y++)
            {
                string stringValue = Convert.ToString(y);
                if (stringValue.Length % 2 == 0)
                {
                    left = stringValue.Substring(0, stringValue.Length / 2);
                    right = stringValue.Substring(stringValue.Length / 2);
                    if (left == right)
                    {
                        total += y;
                    }
                }
            }
        }
        Console.WriteLine(total);
    }
    static void partTwo()
    {
        string[] values;
        ulong first, last;
        string left, right;
        ulong p1total = 0;
        ulong p2total = 0;
        TextReader textFile = new StreamReader("inputData.txt");
        string data = textFile.ReadLine();
        string[] splitData = data.Split(',');
        for (int x = 0; x < splitData.Length; x++)
        {
            values = splitData[x].Split('-');
            first = Convert.ToUInt64(values[0]);
            last = Convert.ToUInt64(values[1]);
            for (ulong y = first; y <= last; y++)
            {
                string stringValue = Convert.ToString(y);
                Regex p1 = new Regex(@"^(\d+?)\1$");
                if (p1.IsMatch(stringValue))
                {
                    p1total += y;
                }
                Regex p2 = new Regex(@"^(\d+?)\1+$");
                if (p2.IsMatch(stringValue))
                {
                    p2total += y;
                }
            }
        }
        Console.WriteLine("Part One: {0}", p1total);
        Console.WriteLine("Part Two: {0}", p2total);
    }
}
