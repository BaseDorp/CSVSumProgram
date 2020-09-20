using System;
using System.Collections.Generic;
using System.IO;

namespace CSVSumAverage
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = Directory.GetCurrentDirectory();
            // get the current filepath
            // TODO create a folder for the csv files if there is not one already
            // TODO throw error if no CSV files are in that folder
            Console.WriteLine(filePath);

            List<string> lines = new List<string>();

            Console.WriteLine("Press Any Key to Continue ...");
            Console.ReadKey();
        }
    }
}
