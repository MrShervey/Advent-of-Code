using System;

class Program
{
    static int getData()
    {
        int total = 0;
        TextReader TextFile = new StreamReader("testData.txt");
        string data = TextFile.ReadToEnd();
        data = data.Replace(Environment.NewLine, " ");
        List<string> fields = new List<string>();
        string[] splitData = data.Split(" ");
        for (int x = 0; x < splitData.Length; x++)
        {
            string[] section = splitData[x].Split(":");
            fields.Add(section[0]);
        }
        if (fields.Count == 8)
        {
            total++;
        }
        else if (fields.Count == 7)
        {
            if (!fields.Contains("cid"))
            {
                total++;
            }
        }  
        return total;         
        }
       
        
    
    static void Main()
    {
        Console.WriteLine(getData());
    }
}
