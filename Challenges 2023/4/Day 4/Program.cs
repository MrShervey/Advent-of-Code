using System;
using System.Data.SqlTypes;
using System.Linq;
class Program
{
    static List<string> values = getData();
    static List<int>winsPerCard = new List<int>();
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
    static void splitting(string data, out string[] winNums, out string[] myNums)
    {
        string[] splitData = data.Split(":");
        string[] newSplit = splitData[1].Split("|");
        string tempWin = newSplit[0];
        winNums = tempWin.Split(" ");
        winNums= winNums.Except(new List<string> { string.Empty }).ToArray();
        string tempNums = newSplit[1];   
        myNums = tempNums.Split(" ");
        myNums= myNums.Except(new List<string> { string.Empty }).ToArray();
    }
    static int taskOne(string data)
    {
        int winCount = 0, cardwins = 0;
        string[] winNums, myNums;
        splitting(data, out winNums, out myNums);
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
                    cardwins++;
                    
                }
            }
        }
        winsPerCard.Add(cardwins);
        return winCount;
    }
    static int taskTwo()
    {
        int[] totalCards = new int[winsPerCard.Count];
        int start = 0;
        for (int x = 0; x < totalCards.Length; x++)
        {
            totalCards[x]++;
            for (int y = 0; y < totalCards[x]; y++)
            {
                start = x+1;
                for (int z = 0; z < winsPerCard[x]; z++)
                {
                    totalCards[start]++;
                    start++;
                }
            }
        }

        return totalCards.Sum();
    }
    static void Main()
    {
        
        int winTotal = 0;
        for (int x = 0; x < values.Count; x++)
        {
            winTotal+=taskOne(values[x]);
        }
        Console.WriteLine("Task 1: {0}",winTotal);
        Console.WriteLine("Task 2: {0}",taskTwo());
    }
}