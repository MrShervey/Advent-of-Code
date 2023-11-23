using System;

class Program
{
    static string[] splittingData(string data)
    {
        string[] splitData = data.Split(" ");
        string[] numbers = splitData[0].Split("-");       
        string[] fullData = new string[4];
        fullData[0] = numbers[0];
        fullData[1] = numbers[1];
        fullData[2] = splitData[1];
        fullData[3] = splitData[2];
        return fullData;
    }
    //Task 1
    static bool checkData(string data)
    {
        string[] fullData = splittingData(data);
        int total = 0;
        for(int count = 0; count < fullData[3].Length; count++)
        {
            if (fullData[3][count] == fullData[2][0])
            {
                total++;
            }
        }
        if (total >= Convert.ToInt32(fullData[0]) && total <= Convert.ToInt32(fullData[1]))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    //Task 2
    static bool taskTwo(string data)
    {
        string[] fullData = splittingData(data);
        if (fullData[3][Convert.ToInt32(fullData[0])-1] == fullData[2][0] ^ fullData[3][Convert.ToInt32(fullData[1])-1] == fullData[2][0])
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    static int getData()
    {
        int total = 0;
        TextReader TextFile = new StreamReader("inputValues.txt");
        string data;
        while ((data = TextFile.ReadLine()) != null)
        {
            if(taskTwo(data))
            {
                total++;
            }
        }
        TextFile.Close();
        return total;
    }
    static void Main()
    {       
        Console.WriteLine(getData());
    }
    
}

