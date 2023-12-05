using System;
using System.Security.Cryptography.X509Certificates;
class Program
{
    // Dictionary<long,long>dictionary = new Dictionary<long,long>();
    static List<string> getData()
    {
        List<string>inputData = new List<string>();
        TextReader textFile = new StreamReader("testData.txt");
        string data;
        while ((data = textFile.ReadLine()) != null)
        {
            inputData.Add(data);
        }
        textFile.Close();
        return inputData;
    } 
    static Dictionary<long,long> createDict(List<string> data)
    {
        Dictionary<long,long>newDict = new Dictionary<long,long>();
        for (int x=0;x<data.Count;x++)
        {
            long[]values = Array.ConvertAll(data[x].Split(" "), long.Parse);
            int add = 0;
            for (int y = 0; y < values[2];y++)
            {
                newDict.Add(values[1]+add,values[0]+add);
                add++;
            }
        }
        return newDict;
    }
    static List<long> checkData(List<string> data)
    {
        Dictionary<long,long>dictionary = new Dictionary<long,long>();
        string[] stringSeeds = data[0].Split(" ");
        List<long>seeds = new List<long>();
        for(int x = 1; x<stringSeeds.Length; x++)
        {
            seeds.Add(Convert.ToInt64(stringSeeds[x]));
        }
        int start = 2;
        for (int x=0; x<7;x++)
        {
            List<string>dictValues = new List<string>();
            start++;
            while(data[start] != "")
            {
                dictValues.Add(data[start]);
                start++;
            }
            start++;
            dictionary.Clear();
            dictionary = createDict(dictValues);
            for (int y = 0; y< seeds.Count;y++)
            {
                if (dictionary.ContainsKey(seeds[y]))
                {
                    seeds[y] = dictionary[seeds[y]];
                }
            }
        }
        return seeds;
    }
    static void Main()
    {
        List<string>inputtedData = getData();
        List<long> finalValues= checkData(inputtedData);
        Console.WriteLine(finalValues.Min());
    }
}
