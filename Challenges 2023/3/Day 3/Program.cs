using System;
using System.Linq;
class Program
{
    static string[] getData()
    {
        string[] inputData = new string[140];
        TextReader textFile = new StreamReader("inputData.txt");
        string data;
        int count = 0;
        while ((data = textFile.ReadLine()) != null)
        {
            inputData[count] = data;
            count++;
        }
        textFile.Close();
        return inputData;
    }
    static int taskOne(string[] data)
    {
        bool adjacent = false;
        string characters = "!£$%^&*():@;'#~/-_+=";
        int total = 0;
        for (int x = 0; x<data.Length;x++)
        {
            string line = data[x];
            string number = string.Empty;
            for (int y = 0; y<data[x].Length; y++)
            {
                if(char.IsDigit(line[y]))
                {
                    number+=line[y];
                    if(!adjacent)
                    {
                        adjacent = checkAdjacancy(data,x,y,line.Length);
                    }                    
                }
                if ((line[y].ToString() == "." || characters.Contains(line[y].ToString()) || y == line.Length-1) && number != "")
                //else if (number != "")
                {
                    if(adjacent == true)
                    {
                        total += Convert.ToInt32(number);
                        Console.WriteLine(number);
                    }
                    number = "";
                    adjacent = false;
                }
            }
        }
        return total;
    }
    static bool checkAdjacancy(string[] data, int x, int y, int len)
    {
        bool found = false;
        string characters = "!£$%^&*():@;'#~/-_+=";
        if (x-1>=0 && y-1>=0 && characters.Contains(data[x-1][y-1].ToString()))
        {
            found =true;
        }
        if (x-1>=0 && characters.Contains(data[x-1][y].ToString()))
        {
            found = true;
        }
        if (x-1>=0 && y+1<len && characters.Contains(data[x-1][y+1].ToString()))
        {
            found =true;
        }
        if (y-1>=0 && characters.Contains(data[x][y-1].ToString()))
        {
            found =true;
        }
        if (y+1<len && characters.Contains(data[x][y+1].ToString()))
        {
            found =true;
        }
        if (x+1<len && y-1>=0 && characters.Contains(data[x+1][y-1].ToString()))
        {
            found =true;
        }
        if (x+1<len && characters.Contains(data[x+1][y].ToString()))
        {
            found =true;
        }
        if (x+1<len && y+1<len && characters.Contains(data[x+1][y+1].ToString()))
        {
            found =true;
        }

        return found;
    }
    static void Main()
    {
        //string test = "952.........................................................793......583..........623............11........730............50.116.........446";
        //Console.WriteLine(test.Length);
        Console.WriteLine(taskOne(getData()));
    }
}
