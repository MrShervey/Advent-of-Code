using System;
using System.Text.RegularExpressions;

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
    static void Main()
    {
        List<string> data = getData();
        int total = 0;
        var matches = Regex.Matches(data[0], @"-?\d+");
        for (int i = 0; i < matches.Count; i++)
        {
            total = total + Convert.ToInt32(matches[i].Value);
        }
        Console.WriteLine(total);
        

        
    }
}
