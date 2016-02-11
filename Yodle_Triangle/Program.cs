using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Yodle_Triangle
{
    class Program
    {
        static void Main(string [] args)
        {
            string line = string.Empty;
            int rowCount = 0;
            Dictionary<int, List<int>> triangle = new Dictionary<int, List<int>>();
            using (StreamReader file = new System.IO.StreamReader("triangle.txt"))
                while ((line = file.ReadLine()) != null)
                {
                    string [] row = line.Trim().Split(' ');
                    triangle.Add(rowCount, Array.ConvertAll(row, o => int.Parse(o)).ToList());
                    rowCount++;
                }

            for (int i = triangle.Count - 2; i >= 0; i--)
            {
                for (int j = 0; j <= i; j++)
                {
                    if (triangle [i + 1] [j] > triangle [i + 1] [j + 1])
                        triangle [i] [j] += triangle [i + 1] [j];
                    else
                        triangle [i] [j] += triangle [i + 1] [j + 1];
                }
            }

            Console.WriteLine(triangle.First().Value.First());
            Console.Read();
        }
    }
}
