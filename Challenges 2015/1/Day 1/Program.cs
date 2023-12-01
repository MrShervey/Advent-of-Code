using System;
class Program
{
        static string getData()
    {
        TextReader textFile = new StreamReader("inputData.txt");
        string data = textFile.ReadLine();
        textFile.Close();
        return data;
    }
    static int taskOne(string data)
    {
        int floor = 0;
        for (int x = 0; x < data.Length; x++)
        {
            if (data[x].ToString() == "(")
            {
                floor++;
            }
            else
            {
                floor--;
            }
            if (floor == -1)
            {
                return x+1;
            }
        }
        return floor;
    }
    static void Main()
    {
        Console.WriteLine(taskOne(getData()));
    }
}
