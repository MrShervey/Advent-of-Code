using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Day_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputData;
            byte[] tmpSource;
            byte[] tmpHash;
            inputData = "iwrupvqb";
            bool result = false;
            int value = 0;
            string fullData;
            string finalData;
            do
            {
                fullData = inputData + value;
                tmpSource = ASCIIEncoding.ASCII.GetBytes(fullData);
                tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);
                finalData = BitConverter.ToString(tmpHash);
                finalData = finalData.Replace("-", string.Empty);
                if (finalData.Substring(0, 6) == "000000")
            {
                result = true;
            }
            else
            {
                value++;
            }
        } while (!result);


            Console.WriteLine(value);
            Console.ReadLine();
        }
    }
}
