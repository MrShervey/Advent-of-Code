using System;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
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
    //task1
    static List<long> taskOne(List<string> data)
    {
        string[] stringSeeds = data[0].Split(": ");
        List<long>seeds = Array.ConvertAll(stringSeeds[1].Split(" "),long.Parse).ToList();
        bool[] seen = new bool[seeds.Count];
        int start = 1;
        for (int z=0; z<7; z++)
        {
            for(int y = 0; y<seeds.Count; y++)
            {
                seen[y] = false;
            }
            start+=2;
            while(data[start] != "")
            {
                long[] newValues = Array.ConvertAll(data[start].Split(" "),long.Parse);
                for(int y = 0; y<seeds.Count;y++)
                {
                    if (seen[y] == false)
                    {
                        if (seeds[y]>=newValues[1] && seeds[y] <= (newValues[1]+newValues[2]))
                        {
                            seeds[y] = newValues[0] + (seeds[y]-newValues[1]);
                            seen[y] = true;
                        }
                    }
                }
                start++;               
            }  
        } 
        return seeds;
    }
    //task 2
    static List<BigInteger> taskTwo(List<string>data)
    {
        string[] stringSeeds = data[0].Split(": ");
        List<BigInteger>seeds = Array.ConvertAll(stringSeeds[1].Split(" "),BigInteger.Parse).ToList();
        List<BigInteger>newSeeds  = new List<BigInteger>();
        int count = 0;
        for (int x = 0; x< seeds.Count;x+=2)
        {
            for (int y = 0; y < seeds[x+1];y++)
            {
                newSeeds.Add(seeds[x]+y);
            }
        }
        bool[] seen = new bool[seeds.Count];
        int start = 1;
        for (int z=0; z<7; z++)
        {
            for(int y = 0; y<seeds.Count; y++)
            {
                seen[y] = false;
            }
            start+=2;
            while(data[start] != "")
            {
                BigInteger[] newValues = Array.ConvertAll(data[start].Split(" "),BigInteger.Parse);
                for(int y = 0; y<seeds.Count;y++)
                {
                    if (seen[y] == false)
                    {
                        if (newSeeds[y]>=newValues[1] && newSeeds[y] <= (newValues[1]+newValues[2]))
                        {
                            newSeeds[y] = newValues[0] + (newSeeds[y]-newValues[1]);
                            seen[y] = true;
                        }
                    }
                }
                start++;               
            }  
        } 
        return newSeeds;
    }
    static void Main()
    {
        
        List<string>inputtedData = getData();
        List<long>taskOneValues = taskOne(inputtedData);
        Console.WriteLine("Task One: {0}",taskOneValues.Min());
        List<BigInteger> taskTwoValues= taskTwo(inputtedData);
        Console.WriteLine("Task Two: {0}",taskTwoValues.Min());
    }
}
