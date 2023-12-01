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
        int index;
        int lastIndex;
        if (data.Contains("one"))
        {
            index = data.IndexOf("one")+1;
            data = data.Insert(index,"1");
            lastIndex = data.LastIndexOf("one")+1;
            if (lastIndex != 0)
            {
                 data = data.Insert(lastIndex,"1");
            }          
        }
        if (data.Contains("two"))
        {
            index = data.IndexOf("two")+1;
            data = data.Insert(index,"2");
            lastIndex = data.LastIndexOf("two")+1;
            if (lastIndex != 0)
            {
                 data = data.Insert(lastIndex,"2");
            }  
        }
        if (data.Contains("three"))
        {
            index = data.IndexOf("three")+1;
            data = data.Insert(index,"3");
            lastIndex = data.LastIndexOf("three")+1;
            if (lastIndex != 0)
            {
                 data = data.Insert(lastIndex,"3");
            }  
        }
        if (data.Contains("four"))
        {
            index = data.IndexOf("four")+1;
            data = data.Insert(index,"4");
            lastIndex = data.LastIndexOf("four")+1;
            if (lastIndex != 0)
            {
                 data = data.Insert(lastIndex,"4");
            }  
        }
        if (data.Contains("five"))
        {
            index = data.IndexOf("five")+1;
            data = data.Insert(index,"5");
            lastIndex = data.LastIndexOf("five")+1;
            if (lastIndex != 0)
            {
                 data = data.Insert(lastIndex,"5");
            }  
        }
        if (data.Contains("six"))
        {
            index = data.IndexOf("six")+1;
            data = data.Insert(index,"6");
            lastIndex = data.LastIndexOf("six")+1;
            if (lastIndex != 0)
            {
                 data = data.Insert(lastIndex,"6");
            }  
        }
        if (data.Contains("seven"))
        {
            index = data.IndexOf("seven")+1;
            data = data.Insert(index,"7");
            lastIndex = data.LastIndexOf("seven")+1;
            if (lastIndex != 0)
            {
                 data = data.Insert(lastIndex,"7");
            }  
        }
        if (data.Contains("eight"))
        {
            index = data.IndexOf("eight")+1;
            data = data.Insert(index,"8");
            lastIndex = data.LastIndexOf("eight")+1;
            if (lastIndex != 0)
            {
                 data = data.Insert(lastIndex,"8");
            }  
        }
        if (data.Contains("nine"))
        {
            index = data.IndexOf("nine")+1;
            data = data.Insert(index,"9");
            lastIndex = data.LastIndexOf("nine")+1;
            if (lastIndex != 0)
            {
                 data = data.Insert(lastIndex,"9");
            }  
        }
        return data;
        
    }
    static void Main()
    {
        
        List<string> values = getData();
        //run task 1
        // int finalTotalT1 = 0;
        // for (int x = 0; x < values.Count; x++)
        // {
        //     finalTotalT1 += Convert.ToInt32(taskOne(values[x]));
        // }
        // Console.WriteLine(finalTotalT1);
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
