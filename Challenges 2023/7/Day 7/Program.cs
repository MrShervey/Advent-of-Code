using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml.Schema;
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
    static string getHandType(string card)
    {
        string hand;
        Dictionary<string,int>cardTypes = new Dictionary<string, int>()
        {{"A",14},{"2",2},{"3",3},{"4",4},{"5",5},{"6",6},{"7",7},{"8",8},{"9",9},{"T",10},{"J",11},{"Q",12},{"K",13},};
        int[]newcardTypes = new int[5];
        for (int x = 0; x<5;x++)
        {
            newcardTypes[x] = cardTypes[card[x].ToString()];
        }
        var dict = new Dictionary<int, int>();
    
        foreach(var value in newcardTypes)
        {
            dict.TryGetValue(value, out int count);
            dict[value] = count + 1;
        }
        int counter = 0;
        foreach(var item in dict)
        {
            if(item.Value == 2)
            {
                counter++;
            }
        }
        if (dict.ContainsValue(4))
        {
            hand = "Four of a kind";
        }
        else if(dict.ContainsValue(3) && dict.ContainsValue(2))
        {
            hand = "Full House";
        }
        else if(dict.ContainsValue(5))
        {
            hand = "Five of a kind";
        }
        else if(dict.ContainsValue(3))
        {
            hand  = "Three of a kind";
        }
        else if(counter == 2)
        {
            hand = "Two pair";
        }
        else if(dict.ContainsValue(2))
        {
            hand = "One pair";
        }
        else
        {
            hand = "One of a kind";
        }
        return hand;
    }
    static string convert(string value)
    {
        char newValue = 'z';
        for (int x = 0; x < 5; x++)
        {
            switch (value[x])
            {
                case '2':
                    newValue = 'm';
                    break;
                case '3':
                    newValue = 'l';
                    break;
                case '4':
                    newValue = 'k';
                    break;
                case '5':
                    newValue = 'j';
                    break;
                case '6':
                    newValue = 'i';
                    break;
                case '7':
                    newValue = 'h';
                    break;
                case '8':
                    newValue = 'g';
                    break;
                case '9':
                    newValue = 'f';
                    break;
                case 'T':
                    newValue = 'e';
                    break;
                case 'J':
                    newValue = 'd';
                    break;
                case 'Q':
                    newValue = 'c';
                    break;
                case 'K':
                    newValue = 'b';
                    break;
                case 'A':
                    newValue = 'a';
                    break;
            }
            StringBuilder sb = new StringBuilder(value);
            sb[x] = newValue;
           value = sb.ToString();
        }
        return value;
    }
    static List<string>convertAndSort(List<string>data)
    {
        List<string>newData = new List<string>();
        foreach(var item in data)
        {
            newData.Add(convert(item));
        }  
        newData.Sort();
        return newData;
    }
    static void Main()
    {
        List<string>inputData = getData();
        List<string>fiveofakind = new List<string>();
        List<string>fourofakind = new List<string>();
        List<string>threeofakind = new List<string>();
        List<string>fullhouse = new List<string>();
        List<string>twopairs = new List<string>();
        List<string>onepair = new List<string>();
        List<string>oneofakind = new List<string>();
        for (int x = 0; x<inputData.Count;x++)
        {
            string returnedhand = getHandType(inputData[x]);
            switch (returnedhand)
            {
                case "Four of a kind":
                    fourofakind.Add(inputData[x]);
                    break;
                case "Five of a kind":
                    fiveofakind.Add(inputData[x]);
                    break;
                case "Three of a kind":
                    threeofakind.Add(inputData[x]);
                    break;
                case "Full house":
                    fullhouse.Add(inputData[x]);
                    break;
                case "Two pair":
                    twopairs.Add(inputData[x]);
                    break;
                case "One pair":
                    onepair.Add(inputData[x]);
                    break;
                case "One of a kind":
                    oneofakind.Add(inputData[x]);
                    break;
            }
        } 
        List<string>finalList = new List<string>();
        List<string>sortedList = new List<string>();
        if (fourofakind.Count > 0)
        {
            sortedList = convertAndSort(fourofakind);
            finalList.AddRange(sortedList);
        }
        if (fiveofakind.Count > 0)
        {
            sortedList = convertAndSort(fourofakind);
            finalList.AddRange(sortedList);
        }
        if (threeofakind.Count > 0)
        {
            sortedList = convertAndSort(threeofakind);
            finalList.AddRange(sortedList);
        }
        if (fullhouse.Count > 0)
        {
            sortedList = convertAndSort(fullhouse);
            finalList.AddRange(sortedList);
        }
        if (twopairs.Count > 0)
        {
            sortedList = convertAndSort(twopairs);
            finalList.AddRange(sortedList);
        }
        if (onepair.Count > 0)
        {
            sortedList = convertAndSort(onepair);
            finalList.AddRange(sortedList);
        }
        if (oneofakind.Count > 0)
        {
            sortedList = convertAndSort(oneofakind);
            finalList.AddRange(sortedList);
        }
        int total = 0, len = finalList.Count;

        for (int x = 0; x< finalList.Count;x++)
        {
            int value = 0;
            string[] line = finalList[x].Split(" ");
            value = Convert.ToInt32(line[1]);
            total += value * len;
            len--;
        }
        Console.WriteLine(total);
    }
}
