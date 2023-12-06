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
        //Part One test Data
        // int[]time = {7,15,30};
        // int[]distance = {9,40,200};
        long total = 1;
        //Part One full Data
        long[]time = {45,98,83,73};
        long[]distance = {295,1734,1278,1210};
        //Part One
        for (int x = 0; x < time.Length; x++)
        {
            total *= findTimes(time[x], distance[x]);
        }
        Console.WriteLine("Part One: {0}",total);
        //Part Two test data
        // int p2Time  = 71530;
        // int p2Distance = 940200;
        // Console.WriteLine(findTimes(p2Time,p2Distance));
        //Part Two full data
        long p2Time  = 45988373;
        long p2Distance = 295173412781210;
        Console.WriteLine("Part Two: {0}",findTimes(p2Time,p2Distance));
    }
}
