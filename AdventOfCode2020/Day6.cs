using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020
{
    public class Day6
    {
        public static void Process(string fileName)
        {            
            var contents = File.ReadAllText(fileName, Encoding.UTF8);
            var entries = contents
                            .Split("\r\n\r\n")
                            .Select(x => x.Replace("\r\n", " "))
                            .ToList();

            var counts = entries.Select(x => x.Distinct().Count()).Sum();

            Console.WriteLine(counts);
        }
    }
}
