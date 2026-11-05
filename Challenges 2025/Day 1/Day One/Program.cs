using System;
using System.Reflection;
class Program
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

    static void partOne(List<string> inputData)
    {
        int p1total = 0;
        int pointer = 50;
        int value;
        string direction;
        for (int x = 0; x < inputData.Count; x++)
        {
            direction = inputData[x].Substring(0, 1);
            value = int.Parse(inputData[x].Substring(1)) % 100;
            if (direction == "R")
            {
                pointer += value;
                if (pointer > 99)
                {
                    pointer -= 100;
                }
            }
            else
            {
                pointer -= value;
                if (pointer < 0)
                {
                    pointer += 100;
                }
            }
            if (pointer == 0)
            {
                p1total++;
            }
        }
        Console.WriteLine("Part 1 Total: " + p1total);
    }

    static void Main(string[] args)
    {
        List<string> inputData = getData();
        //Solve the problems here
        partOne(inputData);
        brutingPart2(inputData);
    }

    static void brutingPart2(List<string> inputData)
    {
        string direction;
        int value;
        int pointer = 50;
        int count = 0;
        for (int x = 0; x < inputData.Count; x++)
        {
            direction = inputData[x].Substring(0, 1);
            value = int.Parse(inputData[x].Substring(1));
            for (int y = 0; y < value; y++)
            {
                if (direction == "R")
                {
                    pointer++;
                    if (pointer > 99)
                    {
                        pointer = 0;
                    }
                }
                else
                {
                    pointer--;
                    if (pointer < 0)
                    {
                        pointer = 99;
                    }
                }
                if (pointer == 0) 
                { 
                    count++; 
                }
            }
        }
        Console.WriteLine(count);
    }
}
