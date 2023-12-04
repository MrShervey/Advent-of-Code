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
        int winCount = 0;
        string[] splitData = data.Split(":");
        string[] newSplit = splitData[1].Split("|");
        string tempWin = newSplit[0];
        string[] winNums = tempWin.Split(" ");
        winNums= winNums.Except(new List<string> { string.Empty }).ToArray();
        string tempNums = newSplit[1];   
        string[] myNums = tempNums.Split(" ");
        myNums= myNums.Except(new List<string> { string.Empty }).ToArray();
        for (int x = 0; x < winNums.Length; x++)
        {
            for (int y = 0; y < myNums.Length; y++)
            {
                if (Convert.ToInt32(winNums[x]) == Convert.ToInt32(myNums[y]))
                {
                    if (winCount >= 1)
                    {
                        winCount*=2;
                    }
                    else
                    {
                        winCount = 1;
                    }
                    
                }
            }
        }
        return winCount;
    }
    static void Main()
    {
        List<string> values = getData();
        int winTotal = 0;
        for (int x = 0; x < values.Count; x++)
        {
            winTotal+=taskOne(values[x]);
        }
        Console.WriteLine(winTotal);
    }
}