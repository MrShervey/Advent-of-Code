using System;
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
    static string taskTwo(string data)
    {
        data = data.Replace("one","o1e");
        data = data.Replace("two","t2o");
        data = data.Replace("three","th3ee");
        data = data.Replace("four","fo4r");
        data = data.Replace("five","fi5e");
        data = data.Replace("six","s6x");
        data = data.Replace("seven","se7en");
        data = data.Replace("eight","ei8ht");
        data = data.Replace("nine","ni9e");
        return data;
        
    }
    static void Main()
    {
        
        List<string> values = getData();
        //run task 1
        int finalTotalT1 = 0;
        for (int x = 0; x < values.Count; x++)
        {
            finalTotalT1 += Convert.ToInt32(taskOne(values[x]));
        }
        Console.WriteLine(finalTotalT1);
        //run task 2
        int finalTotalT2 = 0;
        List<string>newValues = new List<string>();
        for (int x = 0; x < values.Count; x++)
        {
            newValues.Add(taskTwo(values[x]));
            finalTotalT2 += Convert.ToInt32(taskOne(newValues[x]));
        }
        Console.WriteLine(finalTotalT2);
    }
}
