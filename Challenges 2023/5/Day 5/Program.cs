using System;
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
    //failed attempt using dictionary
    // static Dictionary<long,long> createDict(List<string> data)
    // {
    //     Dictionary<long,long>newDict = new Dictionary<long,long>();
    //     for (int x=0;x<data.Count;x++)
    //     {
    //         long[]values = Array.ConvertAll(data[x].Split(" "), long.Parse);
    //         int add = 0;
    //         for (int y = 0; y < values[2];y++)
    //         {
    //             newDict.Add(values[1]+add,values[0]+add);
    //             add++;
    //         }
    //     }
    //     return newDict;
    // }
    // static List<long> checkData(List<string> data)
    // {
    //     Dictionary<long,long>dictionary = new Dictionary<long,long>();
    //     string[] stringSeeds = data[0].Split(" ");
    //     List<long>seeds = new List<long>();
    //     for(int x = 1; x<stringSeeds.Length; x++)
    //     {
    //         seeds.Add(Convert.ToInt64(stringSeeds[x]));
    //     }
    //     int start = 2;
    //     for (int x=0; x<7;x++)
    //     {
    //         List<string>dictValues = new List<string>();
    //         start++;
    //         while(data[start] != "")
    //         {
    //             dictValues.Add(data[start]);
    //             start++;
    //         }
    //         start++;
    //         dictionary.Clear();
    //         dictionary = createDict(dictValues);
    //         for (int y = 0; y< seeds.Count;y++)
    //         {
    //             if (dictionary.ContainsKey(seeds[y]))
    //             {
    //                 seeds[y] = dictionary[seeds[y]];
    //             }
    //         }
    //     }
    //     return seeds;
    //}

    //task1
    static List<long> checkingRange(List<string> data)
    {
        string[] stringSeeds = data[0].Split(" ");
        List<long>seeds = new List<long>();
        List<bool> seen = new List<bool>();
        for(int y = 1; y<stringSeeds.Length; y++)
        {
            seeds.Add(Convert.ToInt64(stringSeeds[y]));
            seen.Add(false);
        }
        int start = 2;
        for (int z=0; z<7; z++)
        {
            for(int y = 0; y<seeds.Count; y++)
            {
                seen[y] = false;
            }
            start++;
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
            start++;
            // Console.WriteLine("[{0}]", string.Join(", ", seeds));

            // Console.WriteLine();
        } 
        return seeds;
    }
    //task 2
    static List<long> taskTwo(List<string>data)
    {
        string[] stringSeeds = data[0].Split(" ");
        List<long>seeds = new List<long>();
        List<long>newSeeds  = new List<long>();
        for(int y = 1; y<stringSeeds.Length; y++)
        {
            seeds.Add(Convert.ToInt64(stringSeeds[y]));
        }
        int count = 0;
        for (int x = 0; x< seeds.Count;x+=2)
        {
            for (int y = 0; y < seeds[x+1];y++)
            {
                int start = 2;
                for (int z=0; z<7; z++)
                {
                    bool seen = false;
                    newSeeds.Add(seeds[x]+y);
                    start++;
                    while(data[start] != "")
                    {
                        long[] newValues = Array.ConvertAll(data[start].Split(" "),long.Parse);

                        if (!seen)
                        {
                            if (newSeeds[count]>=newValues[1] && newSeeds[count] <= (newValues[1]+newValues[2]))
                            {
                                newSeeds[count] = newValues[0] + (newSeeds[count]-newValues[1]);
                                seen = true;
                            }
                        }
                    
                        start++;                
                    } 
                    count++; 
                    start++;
                }
            }
        }
        return newSeeds;
    }
    static void Main()
    {
        
        List<string>inputtedData = getData();
        checkingRange(inputtedData);
        List<long> finalValues= taskTwo(inputtedData);
        Console.WriteLine(finalValues.Min());
    }
}
