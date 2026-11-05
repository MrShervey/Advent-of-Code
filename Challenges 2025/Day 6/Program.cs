using System;
using System.Runtime.CompilerServices;
class Program
{
    static List<string> getData()
    {
        List<string> inputData = new List<string>();
        TextReader textFile = new StreamReader("testData.txt");
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
        int rowLength=0;
        string[] split = inputData[0].Split(' ');
        split  = split.Where(s => !string.IsNullOrEmpty(s)).ToArray();
        string[,] data = new string[inputData.Count,split.Length];
        for (int x = 0; x < inputData.Count; x++)
        {
            string[] arraysplit = inputData[x].Split(' ');
            arraysplit = arraysplit.Where(s => !string.IsNullOrEmpty(s)).ToArray();
            rowLength = arraysplit.Length;
            for (int y = 0; y < arraysplit.Length; y++)
            {
                data[x,y] = arraysplit[y];
            }
        }
        ulong total = 0;
        for (int col = 0; col < rowLength; col++)
        {
            ulong colTotal = ulong.Parse(data[0,col]);
            string op = data[inputData.Count-1,col];
            for (int row = 1; row < inputData.Count-1; row++)
            { 
                if(op == "*")
                {
                    colTotal *= ulong.Parse(data[row, col]);
                }
                else if (op == "+")
                {
                    colTotal += ulong.Parse(data[row, col]);
                }
            }
            total += colTotal;
        }
        Console.WriteLine(total);
    }
    static void partTwo(List<string> inputData)
    {
        int total = 0, blockTotal = 0, blanks = 0;
        char op = inputData[inputData.Count - 1][0];
        for (int col = 0;  col < inputData[0].Length; col++)
        {
            string number = "";
            blanks = 0;
            for (int row = 0; row < inputData.Count-1; row++)
            {
                char digit = inputData[row][col];
                if (char.IsDigit(digit))
                {
                    number += digit;
                }
                else
                {
                    blanks++;
                }
            }
            if (blanks == inputData.Count - 1)
            {
                total += blockTotal;
                blockTotal = 0;
                op = inputData[inputData.Count - 1][col+1];
            }
            else if (blockTotal == 0)
            {
                blockTotal = int.Parse(number);
            }
            else if (op == '+')
            {
                blockTotal += int.Parse(number);
            }
            else if(op == '*')
            {
                blockTotal *= int.Parse(number);
            }
        }
        total += blockTotal;
        Console.WriteLine(total);  
    }
    static void Main(string[] args)
    {
        List<string> inputData = getData();
        //Solve the problems here
        //partOne(inputData);
        partTwo(inputData);
    }
}