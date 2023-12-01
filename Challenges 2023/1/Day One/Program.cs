using System;

class Program
{
    static List<string> getData()
    {
        List<string>inputData = new List<string>();
        TextReader TextFile = new StreamReader("inputData.txt");
        string data;
        while ((data = TextFile.ReadLine()) != null)
        {
            inputData.Add(data);
        }
        TextFile.Close();
        return inputData;
    }
    static string taskOne(string inputText)
    {
        string total;
        int number;
        List<int> numbers = new List<int>();
        for (int x = 0; x < inputText.Length; x++)
        {
            if(int.TryParse(inputText[x].ToString(), out number))
            {
                numbers.Add(number);
            }
        }
        total = numbers[0].ToString() + numbers[numbers.Count - 1].ToString();
        return total;
    }

    static void Main()
    {
        int finalTotal = 0;
        List<string> values = getData();
        for (int x = 0; x < values.Count; x++)
        {
            finalTotal += Convert.ToInt32(taskOne(values[x]));
        }
        Console.WriteLine(finalTotal);
    }
}
