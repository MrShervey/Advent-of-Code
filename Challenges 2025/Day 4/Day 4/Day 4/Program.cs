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
    static int partOne(List<string> inputData)
    {
        int result = 0, count = 0;
        bool removed = true;
        while (removed)
        {
            removed = false;
            for (int row = 0; row < inputData.Count; row++)
            {
                for (int col = 0; col < inputData[row].Length; col++)
                {
                    count = 0;
                    if (inputData[row][col] == '@')
                    {
                        if ((row == 0 && col == 0) || (row == 0 && col == inputData[row].Length - 1) || (row == inputData.Count - 1 && col == 0) || (row == inputData.Count - 1 && col == inputData[row].Length - 1))
                        { result++;
                        }
                        else if (row == 0)
                        {
                            for (int x = row; x <= row + 1; x++)
                            {
                                for (int y = col - 1; y <= col + 1; y++)
                                {
                                    if (inputData[x][y] == '@')
                                    { count++; }
                                }
                            }
                        }
                        else if (col == 0)
                        {
                            for (int x = row - 1; x <= row + 1; x++)
                            {
                                for (int y = col; y <= col + 1; y++)
                                {
                                    if (inputData[x][y] == '@')
                                    { count++; }
                                }
                            }
                        }
                        else if (col == inputData[row].Length - 1)
                        {
                            for (int x = row - 1; x <= row + 1; x++)
                            {
                                for (int y = col - 1; y <= col; y++)
                                {
                                    if (inputData[x][y] == '@')
                                    { count++; }
                                }
                            }
                        }
                        else if (row == inputData.Count - 1)
                        {
                            for (int x = row - 1; x <= row; x++)
                            {
                                for (int y = col - 1; y <= col + 1; y++)
                                    if (inputData[x][y] == '@')
                                    { count++; }
                            }
                        }
                        else
                        {
                            for (int x = row - 1; x <= row + 1; x++)
                            {
                                for (int y = col - 1; y <= col + 1; y++)
                                {
                                    if (inputData[x][y] == '@')
                                    { count++; }
                                }
                            }
                        }
                    }
                    count--;
                    if (count < 4 && count >= 0)
                    {
                        result++;
                    }
                }
            }
        }
        return result;
    }
    static int partTwo(List<string> inputData)
    {
        int result = 0, count = 0;
        bool removed = true;
        while (removed)
        {
            removed = false;
            for (int row = 0; row < inputData.Count; row++)
            {
                for (int col = 0; col < inputData[row].Length; col++)
                {
                    count = 0;
                    if (inputData[row][col] == '@')
                    {
                        if ((row == 0 && col == 0) || (row == 0 && col == inputData[row].Length - 1) || (row == inputData.Count - 1 && col == 0) || (row == inputData.Count - 1 && col == inputData[row].Length - 1))
                        {
                            string newString = "";
                            for (int x = 0; x < inputData[row].Length; x++)
                            {
                                if (x == col)
                                {
                                    newString += 'x';
                                }
                                else
                                {
                                    newString += inputData[row][x];
                                }
                            }
                            inputData[row] = newString;
                        }
                        else if (row == 0)
                        {
                            for (int x = row; x <= row + 1; x++)
                            {
                                for (int y = col - 1; y <= col + 1; y++)
                                {
                                    if (inputData[x][y] == '@')
                                    { count++; }
                                }
                            }
                        }
                        else if (col == 0)
                        {
                            for (int x = row - 1; x <= row + 1; x++)
                            {
                                for (int y = col; y <= col + 1; y++)
                                {
                                    if (inputData[x][y] == '@')
                                    { count++; }
                                }
                            }
                        }
                        else if (col == inputData[row].Length - 1)
                        {
                            for (int x = row - 1; x <= row + 1; x++)
                            {
                                for (int y = col - 1; y <= col; y++)
                                {
                                    if (inputData[x][y] == '@')
                                    { count++; }
                                }
                            }
                        }
                        else if (row == inputData.Count - 1)
                        {
                            for (int x = row - 1; x <= row; x++)
                            {
                                for (int y = col - 1; y <= col + 1; y++)
                                    if (inputData[x][y] == '@')
                                    { count++; }
                            }
                        }
                        else
                        {
                            for (int x = row - 1; x <= row + 1; x++)
                            {
                                for (int y = col - 1; y <= col + 1; y++)
                                {
                                    if (inputData[x][y] == '@')
                                    { count++; }
                                }
                            }
                        }
                    }
                    count--;
                    if (count < 4 && count >= 0)
                    {
                        string newString = "";
                        for (int x = 0; x < inputData[row].Length; x++)
                        {
                            if (x == col)
                            {
                                newString += 'x';
                            }
                            else
                            {
                                newString += inputData[row][x];
                            }
                        }
                        inputData[row] = newString;
                        removed = true;
                    }
                }
            }
        }
        int answer = 0;
        for (int row = 0; row < inputData.Count; row ++)
        {
            for (int col = 0;  col < inputData[row].Length; col ++)
            {
                if(inputData[row][col] == 'x')
                { answer++;  }
            }
        }
            return answer;
    }
    static void Main(string[] args)
    {
        List<string> inputData = getData();
        //Console.WriteLine("Part One Result: " + partOne(inputData));
        Console.WriteLine("Part Two Result: " + partTwo(inputData));
    }
}
