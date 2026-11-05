using System;

class Program
{
    static void Main()
    {
        string start = "1321131112";
        for (int i = 0; i < 50; i++)
        {
            int count = 0;
            int value = 1;
            char digit = start[count];
            string newString = "";
            bool multi = false;
            do
            {
                if (count < start.Length - 1)
                {
                    while (start[count + 1] == digit)
                    {
                        multi = true;
                        value++;
                        count++;
                    }
                }

                newString = newString + Convert.ToString(value) + Convert.ToString(digit);
                if (multi)
                {
                    multi = false;
                    value = 1;
                }
                if (count < start.Length - 1)
                {
                    digit = start[count + 1];
                }
                count++;
            } while (count < start.Length);
            start = newString;
            Console.WriteLine(i);
        }
        Console.WriteLine(start.Length);
    }
}
