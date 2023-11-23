using System;
using System.Formats.Asn1;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static List<int> getData()
    {
        List<int>inputData = new List<int>();
        TextReader TextFile = new StreamReader("inputValues.txt");
        string data;
        while ((data = TextFile.ReadLine()) != null)
        {
            inputData.Add(Int32.Parse(data));
        }
        TextFile.Close();
        return inputData;
    }
    static void Main()
    {
        int answer = 0;
        List<int> values = new List<int>();
        values = getData();
        for(int x = 0; x < values.Count; x++)
        {
            for (int y = x+1; y < values.Count-1; y++)
            {
                for (int z = y+1; z < values.Count-2;z++)
                {               
                    if((values[x] + values[y] + values[z]) == 2020)
                    {
                        answer = values[x] * values[y] * values[z];
                        break;
                    }
                }
            }
        }
        Console.WriteLine(answer);
    }
}