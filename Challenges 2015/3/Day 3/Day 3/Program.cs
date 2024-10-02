using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_3
{
    internal class Program
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

        static void Main(string[] args)
        {
            //Part 1
            int xPos = 250;
            int yPos = 250;
            int count = 0;
            List<string> inputData = getData();
            int[,] housesArray = new int [500,500];
            housesArray[xPos,yPos]++;
            for (int x = 0; x < inputData.Count; x++)
            {
                for (int y = 0; y < inputData[x].Length; y++)
                {
                    switch (Convert.ToString(inputData[x][y]))
                    {
                        case "<":
                            xPos--;
                            housesArray[xPos,yPos]++; 
                            break;
                        case ">":
                            xPos++;
                            housesArray[xPos,yPos]++;
                            break;
                        case "^":
                            yPos--;
                            housesArray [xPos,yPos]++; 
                            break;
                        case "v":
                            yPos++;
                            housesArray[xPos, yPos]++;
                            break;
                    }
                }
            }
            for (int x = 0; x < housesArray.GetLength(0); x++)
            {
                for (int y = 0; y < housesArray.GetLength(1); y++)
                {
                    if (housesArray[x,y] >= 1)
                    {
                        count++;
                    }
                }
            }
            Console.WriteLine(count);

            //Part 2
            xPos = 250;
            yPos = 250;
            count = 0;
            int[,] newHousesArray = new int[500, 500];
            newHousesArray[xPos, yPos]++;
            for (int x = 0; x < inputData.Count; x++)
            {
                for (int y = 0; y < inputData[x].Length; y+=2)
                {
                    switch (Convert.ToString(inputData[x][y]))
                    {
                        case "<":
                            xPos--;
                            newHousesArray[xPos, yPos]++;
                            break;
                        case ">":
                            xPos++;
                            newHousesArray[xPos, yPos]++;
                            break;
                        case "^":
                            yPos--;
                            newHousesArray[xPos, yPos]++;
                            break;
                        case "v":
                            yPos++;
                            newHousesArray[xPos, yPos]++;
                            break;
                    }
                }
            }
            xPos = 250;
            yPos = 250;
            for (int x = 0; x < inputData.Count; x++)
            {
                for (int y = 1; y < inputData[x].Length; y += 2)
                {
                    switch (Convert.ToString(inputData[x][y]))
                    {
                        case "<":
                            xPos--;
                            newHousesArray[xPos, yPos]++;
                            break;
                        case ">":
                            xPos++;
                            newHousesArray[xPos, yPos]++;
                            break;
                        case "^":
                            yPos--;
                            newHousesArray[xPos, yPos]++;
                            break;
                        case "v":
                            yPos++;
                            newHousesArray[xPos, yPos]++;
                            break;
                    }
                }
            }
            for (int x = 0; x < newHousesArray.GetLength(0); x++)
            {
                for (int y = 0; y < newHousesArray.GetLength(1); y++)
                {
                    if (newHousesArray[x, y] >= 1)
                    {
                        count++;
                    }
                }
            }
            Console.WriteLine(count);


            Console.ReadLine();
        }
    }
}
