using System;

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
    static int[] splitData(string data)
    {
        string[] splitData = data.Split(" ");
        int[] values = new int[3];
        values[0] = Convert.ToInt32(splitData[3]);
        values[1] = Convert.ToInt32(splitData[6]);
        values[2] = Convert.ToInt32(splitData[13]);
        return values;
    }
    
    static void Main()
    {
        List<string>inputData = getData();
        int[] totalDistances = new int[9];
        for (int i = 0; i < inputData.Count; i++)
        {
            totalDistances[i] = distance(splitData(inputData[i]));
        }
        Console.WriteLine(totalDistances.Max());

        

    static int distance(int[] values)
    {
        int totalDistance = 0, newTime = values[1], newRest = values[2];
        for (int i = 0; i < 2503; i++)
        {
            if (newTime > 0)
            {
                totalDistance += values[0];
                newTime--;
            }
            else
            {
                newRest--;
            }
            if (newTime == 0 && newRest == 0)
            {
                newTime = values[1];
                newRest = values[2];
            }
        }
        return totalDistance;
    }
}
