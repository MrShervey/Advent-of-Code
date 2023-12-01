using System;
using System.Linq;
class Program
{
        static List<string> getData()
    {
        List<string>inputData = new List<string>();
        TextReader textFile = new StreamReader("inputData.txt");
        string data;
        while ((data = textFile.ReadLine()) != null)
        {
            inputData.Add(data);
        }
        textFile.Close();
        return inputData;
    }
    static int taskOne(string data)
    {
        int total = 0;
        string[] splitData = data.Split("x");
        int[] sides = new int[3];

        sides[0] = Convert.ToInt32(splitData[0]) * Convert.ToInt32(splitData[1]);
        sides[1] = Convert.ToInt32(splitData[1]) * Convert.ToInt32(splitData[2]);
        sides[2] = Convert.ToInt32(splitData[0]) * Convert.ToInt32(splitData[2]);
        for (int x = 0; x < sides.Length; x++)
        {
            total += (2 * sides[x]);
        }
        int max = sides.Min();
        total += max;
        return total;
    }
    static int taskTwo(string data)
    {
        int ribbon, bow, total = 0;
        string[] splitData = data.Split("x");
        int[] sides = new int[3];
        for (int x = 0; x < sides.Length; x++)
        {
            sides[x] = Convert.ToInt32(splitData[x]);
        }
        Array.Sort(sides);
        ribbon = (sides[0] * 2) + (sides[1] * 2);
        bow = sides[0] * sides[1] * sides[2];
        total = ribbon + bow;
        return total;
    }
    static void Main()
    {
        int task1Total = 0, task2Total = 0;
        List<string>inputData = getData();
        for (int x = 0; x < inputData.Count; x++)
        {
           task1Total += taskOne(inputData[x]);
           task2Total += taskTwo(inputData[x]);
        }
        Console.WriteLine("Task 1 answer: {0}", task1Total);
        Console.WriteLine("Task 2 answer: {0}", task2Total);
    }
}
