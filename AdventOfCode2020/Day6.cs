using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020
{
    public class Day6
    {
        public static void Process()
        {
            Part2(fileName: @"Inputs\Day6.txt");
        }

        private static void Part1(string fileName)
        {
            var contents = File.ReadAllText(fileName, Encoding.UTF8);
            var entries = contents
                            .Split("\r\n\r\n")
                            .Select(x => x.Replace("\r\n", " "))
                            .ToList();

            var count = entries.Select(x => x.Distinct()).Select(x => x.Count()).Sum();
            //var count = uniqs.Select(x => x.Count()).Sum();
            Console.WriteLine(count);
        }

        private static void Part2(string fileName)
        {
            var contents = File.ReadAllText(fileName, Encoding.UTF8);
            var groups = contents
                            .Split("\r\n\r\n")                            
                            .Select(x => x.Split("\r\n"))
                            .Select(
                                    y => y.Select(z=>z.ToCharArray().ToList())
                                            .Aggregate((previousList, nextList) => previousList.Intersect(nextList)
                                            .ToList())
                                    )
                            .ToList();

            
            var count = groups.Select(x => x.Distinct()).Select(x => x.Count()).Sum();

            Console.WriteLine(count);
        }
    }
}
