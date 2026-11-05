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
    static int partOne(List<string> ranges, List<string> ids)
    {
        int total = 0;
        ulong integerId;
        string[] splitR = new string[2];
        ulong[] splitRange = new ulong[2];
        for (int x = 0; x < ids.Count; x++)
        {
            integerId = ulong.Parse(ids[x]);
            for (int y = 0; y < ranges.Count; y++)
            {
                splitR = ranges[y].Split('-');
                splitRange[0] = ulong.Parse(splitR[0]);
                splitRange[1] = ulong.Parse(splitR[1]);
                if (integerId >= splitRange[0] && integerId <= splitRange[1])
                {
                    total++;
                    break;
                }
            }
        }
        return total;
    }
    static ulong partTwo(List <string> ranges)
    {
        string[] splitRange = new string[2];
        ulong[][] values = new ulong[ranges.Count][];
        for (int x = 0; x < values.Length; x++)
        {
            splitRange = ranges[x].Split('-');
            values[x] = new ulong[] { ulong.Parse(splitRange[0]) , ulong.Parse(splitRange[1]) };
        }
        //Array.Sort(values, (a, b) => a[0].CompareTo(b[0]));
        Array.Sort(values);
        List<ulong[]> result = new List<ulong[]>();
        result.Add(new ulong[] { values[0][0], values[0][1]  });
        int count = 0;
        for (int i = 1; i < values.Length; i++)
        {
            if(values[i][0] >= result[count][0] && values[i][0] <= result[count][1] && values[i][1] > result[count][1])
            {
                result[count][1] = values[i][1];
            }
            else if (values[i][0] > result[count][1])
            {
                result.Add(new ulong[] { values[i][0], values[i][1] });
                count++;
            }
        }
        ulong total = 0;
        for (int i = 0; i < result.Count; i++)
        {
            total += ((result[i][1] - result[i][0]) + 1);
        }
        return total;
    }
    static void Main(string[] args)
    {
        List<string> inputData = getData();
        List<string> ranges = new List<string>();
        List<string> ids = new List<string>();
        int count = 0;
        string data = "n";
        while (data != "")
        {
            data = inputData[count];
            if (data != "")
            {
                ranges.Add(data);
                count++;
            }
        }
        for (int x = count + 1; x < inputData.Count; x++)
        {
            ids.Add(inputData[x]);
        }
        Console.WriteLine("Part One: {0}",partOne(ranges, ids));
        Console.WriteLine("Part Two: {0}", partTwo(ranges));
    }
}