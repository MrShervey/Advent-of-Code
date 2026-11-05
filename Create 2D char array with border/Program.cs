using System;
class Program
{
    static List<string> getData()
    {
        List<string> inputData = new List<string>();
        TextReader textFile = new StreamReader("testData.txt");
        string data;
        while ((data = textFile.ReadLine()) != null)
        {
            inputData.Add(data);
        }
        textFile.Close();
        return inputData;
    }
    static char[,] twoD (List<string> inputData)
    {
        char[,] array = new char[inputData.Count+2,inputData[0].Length+2];
        for(int x =  0; x < inputData.Count;)
        {
            char[] charArray = inputData[x].ToCharArray();
            for (int y =  0; y < charArray.Length; y++)
            {
                array[x,y] = charArray[y];
            }
        }
        return array;
    }
    static void Main(string[] args)
    {
        List<string> inputData = getData();
        char[,] thisArray = twoD(inputData);
    }
}
