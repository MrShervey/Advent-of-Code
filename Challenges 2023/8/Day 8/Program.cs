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
    static void taskOne(List<string>inputData)
    {
        var data = new Dictionary<string,string>();
        string instructions = inputData[0];
        for (int x = 2; x < inputData.Count; x++)
        {
            data.Add(inputData[x].Substring(0,3), inputData[x].Substring(7,8));
        }
        int count = 0;
        int instructionCount = 0;
        string[] children = new string[2];
        string currentNode = "AAA";
        while (currentNode != "ZZZ")
        {
            children[0] = data[currentNode].Substring(0,3);
            children[1] = data[currentNode].Substring(5,3);
            if (instructions[instructionCount].ToString() == "L")
            {
                currentNode = children[0];
            }
            else{
                currentNode = children[1];
            }
            count++;
            instructionCount++;
            if (instructionCount == instructions.Length)
            {
                instructionCount = 0;
            }
        }
        Console.WriteLine(count);
    }

    static void taskTwo(List<string>inputData)
    {
        var data = new Dictionary<string,string>();
        string instructions = inputData[0];
        for (int x = 2; x < inputData.Count; x++)
        {
            data.Add(inputData[x].Substring(0,3), inputData[x].Substring(7,8));
        }
        List<string> nodes = new List<string>();
        foreach (var item in data)
        {
            if (item.Key[2].ToString() == "A")
            {
                nodes.Add(item.Value);
            }
        }
        int total = 0;
        int count = 0;
        int index = 0;
        while (count < nodes.Count)
        {
            for (int x = 0; x < nodes.Count; x++)
            {
                if (instructions[index].ToString() == "L")
                {
                    if (nodes[x].Substring(2,1).ToString() == "Z")
                    {
                        count ++;
                    }
                    nodes[x] = data[nodes[x].Substring(0,3)];
                }
                else
                {
                    if (nodes[x].Substring(7,1).ToString() == "Z")
                    {
                        count ++;
                    }
                    nodes[x] = data[nodes[x].Substring(5,3)];
                }
                
            }
            total++;
            index++;
            if (index == instructions.Length)
            {
                index = 0;
            }
            if (count != nodes.Count)
            {
                count = 0;
            }
        }
        Console.WriteLine(total);
    }
    
    static void Main()
    {
        List<string> data = getData();
        //taskOne(data);
        taskTwo(data);
    }
}
