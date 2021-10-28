using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
    public class Day2
    {
        public void Part1()
        {
            Console.WriteLine(File.ReadAllLines(@"Inputs\Day2.txt").Select(x => IsValidPassword(x, false)).Where(y => y == true).Count());
        }

        private static (char,int,int) GetRule(string rule)
        {
            var res = new Regex(@"([0-9]+)-([0-9]+) ([a-z])", RegexOptions.IgnoreCase).Match(rule);            
            return (char.Parse(res.Groups[3].Value), int.Parse(res.Groups[1].Value), int.Parse(res.Groups[2].Value));
        }

        private static bool IsValidPassword(string line, bool isPart1)
        {
            bool isValid;

            var entry = line.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
            var rule = GetRule(entry[0]);            
            var chars = entry[1].Trim().ToArray();

            if (isPart1)
            {
                var count = chars.Where(x => x == rule.Item1).Count();
                isValid = count >= rule.Item2 && count <= rule.Item3;
            } else
            {                
                isValid = chars[rule.Item2 - 1] == rule.Item1 ^ chars[rule.Item3 - 1] == rule.Item1;

                if (isValid)
                    Console.WriteLine(line);
            }

            return isValid;

        }       
    }
}
