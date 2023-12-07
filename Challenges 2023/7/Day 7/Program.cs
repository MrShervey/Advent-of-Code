using System;
class Program
{   
    static List<string> getData()
    {
        List<string>inputData = new List<string>();
        TextReader textFile = new StreamReader("testData.txt");
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
        {{"A",1},{"2",2},{"3",3},{"4",4},{"5",5},{"6",6},{"7",7},{"8",8},{"9",9},{"T",10},{"J",11},{"Q",12},{"K",13},};
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
    }
}
