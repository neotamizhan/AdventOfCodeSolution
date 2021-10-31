using System;
using System.Collections.Generic;
using System.Linq.Expressions;

using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2020
{
    internal class Day7
    {
        public static void Process()
        {
            var BagList = Bag.LoadAllFromFile(@"Inputs\Day7.txt");
            Part1(BagList);

        }

        private static void Part1(List<Bag> BagList)
        {
            var goldBags = BagList.Where(x => x.CanHold("shiny gold", BagList)).ToList();

            Console.WriteLine(goldBags.Count());
        }

        internal record Bag (string Color, Dictionary<string, int> InnerBags)
        {
            public bool CanHold(string color, List<Bag> bagList)
            {
                return CanDirectlyHold(color) || CanIndirectlyHold(color, bagList);
            }
            public bool CanDirectlyHold(string color)
            {
                return InnerBags.ContainsKey(color);
            }

            public bool CanIndirectlyHold(string color, List<Bag> baglist)
            {
                foreach (var bag in InnerBags)
                {
                    var topBag = baglist.FirstOrDefault(x => x.Color == bag.Key);
                    if (topBag.CanHold(color, baglist))
                        return true;
                }

                return false;
            }

            public int TotalBags(List<Bag> baglist)
            {
                var totalBags = 0;
                foreach (var bag in InnerBags)
                {
                    baglist.FirstOrDefault(x => x.Color == bag.Key);

                }

                return totalBags;
            }

            public static List<Bag> LoadAllFromFile(string fileName)
            {
                var contents = File.ReadAllLines(fileName);
                return contents.Select(x=>LoadFromString(x)).ToList();
            }

            public static Bag LoadFromString(string line)
            {
                var lev1 = line
                                .Replace("bags","")
                                .Replace("bag", "")
                                .Replace(".", "")
                                .Split("contain");

                var inner = new Dictionary<string, int>();
                var groups = lev1[1].Split(",").Select(x => new Regex("([0-9]+) (.*)").Match(x));
                foreach (var group in groups)
                {
                    if (group.Success)
                        inner.Add(group.Groups[2].Value.Replace(".", "").Trim(), int.Parse(group.Groups[1].Value));
                }

                return new Bag(lev1[0].Trim(), inner);
            }
        }
    }
}
