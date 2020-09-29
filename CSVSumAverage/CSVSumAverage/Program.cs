using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CSVSumAverage
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = Directory.GetCurrentDirectory() + "/test.csv";
            // TODO create a folder for the csv files if there is not one already
            // TODO throw error if no CSV files are in that folder
            Console.WriteLine(filePath);

            // TODO make bool to show if reader is inside quotes

            using (StreamReader reader = new StreamReader(filePath))
            {
                List<string> listA = new List<string>();

                
                bool insideCell = false;
                // String of current cell
                string line = string.Empty;
                List<string> values = new List<string>();

                while (!reader.EndOfStream)
                {
                    // Reads in text from csv file
                    line = reader.ReadLine();
                    Console.WriteLine(reader.ReadLine());
                    string cell = "";

                    // Searches all characters in the file
                    foreach (char item in line)
                    {
                        
                        // flip flops the bool depending if item char is quotes
                        if (item == '"')
                        {
                            insideCell = !insideCell;
                        }

                        // if the char is not inside of a cell, then add the cell to the list
                        if (!insideCell)
                        {
                            values.Add(cell);
                            cell = "";
                        }
                        else
                        {
                            cell += item;
                        }
                    }
                    

                    // Goes through the cells
                    for (int i = 0; i < values.Count; i++)
                    {
                        // for each char in the string
                        foreach (char character in values[i])
                        {
                            // returns bool if char is a number
                            if (!Char.IsDigit(character) && character != '.')
                            {
                                values[i] = values[i].Replace(character, 'b');
                            }
                        }
                        values[i] = values[i].Replace("b", "");
                        if (values[i] != "")
                        {
                            listA.Add(values[i]);
                        }
                    }
                }

                float total = 0.0f;

                foreach (string item in listA)
                {
                    total += float.Parse(item);
                }

                float average = total / listA.Count();
            }

            // TODO create an CSV with total and average

            Console.WriteLine("Press Any Key to Continue ...");
            Console.ReadKey();
        }
    }
}
