using System;

class Program
{
    static List<string> getData()
    {
        TextReader TextFile = new StreamReader("dataSet.txt");
        string data;
        List<string> fullData = new List<string>();
        while ((data = TextFile.ReadLine()) != null)
        {
            fullData.Add(data);
        }
        TextFile.Close();
        return fullData;
    }
    static int taskOneChanged(int right, int down)
    {
        List<string> dataSet = getData();
        int open = 0, trees = 0, row = 0, column = 0;
        int length = dataSet[0].Length;
        while (row < 322)
        {
            column += right;
            row += down;
            if (column > length-1)
            {
                column = (column - (length-1)) - 1;
            }
            if (Convert.ToString(dataSet[row][column]) == ".")
            {
                open++;
            }
            else
            {
                trees++;
            }
        }

        return trees;
    }
    static void Main()
    {
        
        int val1 = taskOneChanged(1,1);
        int val2 = taskOneChanged(3,1);
        int val3 = taskOneChanged(5,1);
        int val4 = taskOneChanged(7,1);
        int val5 = taskOneChanged(1,2);
        double total = val1 * val2 * val3 * val4 * val5;
        Console.WriteLine(total);
        
    }
}
