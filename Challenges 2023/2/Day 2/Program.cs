using System;
using System.Runtime.CompilerServices;
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
    static int part1(string data)
    {
        bool posGame = true;
        int gameID, maxRed = 12, maxGreen = 13, maxBlue = 14;
        string[] splitData = data.Split(":");
        string[] tempID = splitData[0].Split(" ");
        gameID = Convert.ToInt32(tempID[1]);
        string[] splitGames = splitData[1].Split(";");
        for(int x = 0; x < splitGames.Length; x++)
        {
            if (posGame)
            {
                string[] colours = splitGames[x].Split(",");
                for (int y = 0; y < colours.Length; y++)
                {
                    int num;
                    string[]values = colours[y].Split(" ");
                    num = Convert.ToInt32(values[1]);
                    switch (values[2])
                    {
                        case "red":
                            if (num > maxRed)
                            {
                                posGame = false;
                            }
                            break;
                        case "green":
                            if (num > maxGreen)
                            {
                                posGame = false;
                            }
                            break;
                        case "blue":
                            if (num > maxBlue)
                            {
                                posGame = false;
                            }
                            break;
                        default:
                            break;
                    }
                }
            }

        }
        if(posGame)
        {
            return gameID;
        }
        else
        {
            return 0;
        }
    }
    static int part2(string data)
    {
        int power = 0, maxRed = 0, maxGreen = 0, maxBlue = 0;
        string[] splitData = data.Split(":");
        string[] splitGames = splitData[1].Split(";");
        for (int x = 0; x < splitGames.Length; x++)
        {
            string[] colours = splitGames[x].Split(",");
            for (int y = 0; y < colours.Length; y++)
            {
                int num = 0;
                string[]values = colours[y].Split(" ");
                num = Convert.ToInt32(values[1]);
                switch (values[2])
                {
                    case "red":
                        if (num > maxRed)
                        {
                            maxRed = num;
                        }
                        break;
                    case "green":
                        if (num > maxGreen)
                        {
                            maxGreen = num;
                        }
                        break;
                    case "blue":
                        if (num > maxBlue)
                        {
                            maxBlue = num;
                        }
                        break;
                    default:
                        break;
                }
            }
        }     
        power = maxBlue*maxGreen*maxRed; 
        return power;
    }
    static void Main()
    {
        List<string>inputData = getData();
        int totalIDs = 0, totalPower = 0;
        for (int x = 0; x < inputData.Count; x++)
        {
            totalIDs += part1(inputData[x]);
            totalPower += part2(inputData[x]);
        }
        Console.WriteLine("Part 1: {0}",totalIDs);
        Console.WriteLine("Part 2: {0}",totalPower);
    }
}
