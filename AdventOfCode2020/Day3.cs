using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
    public class Day3
    {
        char[][] map = { };

        public void Part1()
        {                        
            map = File.ReadAllLines(@"Inputs\Day3.txt").Select(x => x.ToCharArray()).ToArray();

            (int,int)[] slopes = { (1, 1), (3, 1), (5, 1), (7, 1), (1, 2)};

            var treeMap = slopes.Select(x => GetTrees(x.Item1, x.Item2)).ToArray();
            long product = treeMap.Aggregate((total, next) => total * next);

            Console.WriteLine("Trees = {0}", product);
        }

        private long GetTrees(int right, int down)
        {
            long trees = 0;
            int pos = 0, line = 0;

            while (line < map.Length - 1)
            {
                pos += right; line += down;
                if (pos >= map[0].Length)
                    pos = pos - map[0].Length;

                var here = map[line][pos];

                if (here == '#')
                    trees++;
            }

            return trees;
        }

    }
}
