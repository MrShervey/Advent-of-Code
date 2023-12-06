using System;
class Program
{
    static long findTimes(long raceTime, long raceDistance)
    {
        int races = 0;
        for (int x = 0; x < raceTime; x++)
        {
            if((raceTime-x)*x > raceDistance)
            {
                races++;
            }
        }
        return races;
    }
    static void Main()
    {
        //test Data
        // int[]time = {7,15,30};
        // int[]distance = {9,40,200};
        long total = 1;
        //full Data
        int[]time = {45,98,83,73};
        long[]distance = {295,1734,1278,1210};
        // for (int x = 0; x < time.Length; x++)
        // {
        //     total *= findTimes(time[x], distance[x]);
        // }
        // Console.WriteLine(total);
        //Task Two test
        //Console.WriteLine(findTimes(71530,940200));
        //Task Two full data
        Console.WriteLine(findTimes(45988373,295173412781210));
    }
}
