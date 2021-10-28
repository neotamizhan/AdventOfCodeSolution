using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020
{
    public static class Helper
    {
        public static int[] GetInputAsArray(string input)
        {
            return input.Split("\n").Select(x => int.Parse(x)).ToArray();
        }
    }
}
