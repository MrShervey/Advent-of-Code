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

    static void Main(string[] args)
    {
        List<string> inputData = getData();
        int p1Total = 0;
        ulong p2Total = 0;
        for (int x = 0; x < inputData.Count; x++)
        {
            char[] charArray = inputData[x].ToCharArray();
            int[] intArray = new int[charArray.Length];
            for (int y = 0; y < charArray.Length; y++)
            {
                intArray[y] = (int)charArray[y];
            }
            p1Total += int.Parse(partOne(intArray));
            p2Total += ulong.Parse(partTwo(intArray));
        }
        Console.WriteLine("Part One Total: " + p1Total);
        Console.WriteLine("Part Two Total: " + p2Total);
    }
    static string partOne(int[] intArray)
    {
        int maxInRange;
        string result;
        int maxValue = intArray.Max();
        int maxIndex = Array.IndexOf(intArray, maxValue);
        if (maxIndex == intArray.Length - 1)
        {
            maxInRange = intArray.Take(intArray.Length - 1).Max();
            result = ((char)maxInRange).ToString() + ((char)maxValue).ToString();
        }
        else
        {
            maxInRange = intArray.Skip(maxIndex + 1).Max();
            result = ((char)maxValue).ToString() + ((char)maxInRange).ToString();
        }
        return result;
    }
    static string partTwo(int[] intArray)
    {
        string result = "";
        int maxValue, maxIndex = 0, start = 0, end = 11, endIndex;
        while (result.Length != 12)
        {
            endIndex = intArray.Length - end;
            maxValue = intArray[start];
            maxIndex = start;
            for (int x = start; x < endIndex; x++)
            {
                if (intArray[x] > maxValue)
                {
                    maxValue = intArray[x];
                    maxIndex = x;
                }
            }
            result += ((char)maxValue).ToString();
            end--;
            start = maxIndex + 1;
        }
        return result;
    }    
}