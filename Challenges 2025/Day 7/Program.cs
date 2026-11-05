using System;
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
    static char[,] twoD(List<string> inputData)
    {
        char[,] array = new char[inputData.Count + 2, inputData[0].Length + 2];
        for (int x = 0; x < inputData.Count; x++)
        {
            char[] charArray = inputData[x].ToCharArray();
            for (int y = 0; y < charArray.Length; y++)
            {
                array[x, y] = charArray[y];
            }
        }
        return array;
    }
    static void partOne(char[,] inputData)
    {
        int splitCount = 0;
        int rowLength = inputData.GetLength(0);
        int colLength = inputData.GetLength(1);
        for (int x = 0; x < inputData.GetLength(1); x++)
        {
            if (inputData[0,x] == 'S')
            {
                inputData[1, x] = '|';
                break;
            }
        }
        for (int row = 2; row < rowLength-1; row++)
        {
            for (int col = 0; col < colLength; col++)
            {
                if (inputData[row, col] == '^' && inputData[row - 1, col] == '|')
                {
                    splitCount++;
                    inputData[row, col - 1] = '|';
                    inputData[row, col + 1] = '|';
                }
                else if (inputData[row-1, col] == '|')
                {
                    inputData[row, col] = '|';
                }
            }
        }
        Console.WriteLine(splitCount);
    }
    static void Main(string[] args)
    {
        List<string> inputData = getData();
        //Solve the problems here
        char[,] thisArray = twoD(inputData);
        partOne(thisArray);
    }
}
