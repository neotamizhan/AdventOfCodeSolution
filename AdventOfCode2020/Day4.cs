using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2020
{
    public class Day4
    {
        public static void Process()
        {
            var passports = Passport.LoadAllFromFile(@"Inputs\Day4.txt");
            var validPPs = passports.Where(p => p.IsValidID);
            File.WriteAllLines(@"Inputs\valid_day4.txt", validPPs.Select(p => p.ToString()));
            Console.WriteLine(validPPs.Count());
        }

        internal class Passport
        {
            private Regex HclPattern = new Regex("#[a-z0-9]{6}");
            private Regex EclPattern = new Regex("(amb|blu|gry|brn|grn|hzl|oth)");
            private Regex PidPattern = new Regex("[0-9]{9}");
            private Regex HgtPattern = new Regex("([0-9]+)(cm|in)");
            private Regex YearPattern = new Regex("[0-9]{4}");

            public Dictionary<string,string> Fields { get; set; }
            public string Entry { get; set; }

            public Passport()
            {
                Fields = new Dictionary<string, string>(8);
            }
            public bool IsValidID { 
                get {
                    return
                        Fields.ContainsKey("byr") && YearPattern.IsMatch(Fields["byr"]) && int.TryParse(Fields["byr"], out int byr) && (byr >= 1920 && byr <= 2002) &&  
                        Fields.ContainsKey("iyr") && YearPattern.IsMatch(Fields["iyr"]) && int.TryParse(Fields["iyr"], out int iyr) && (iyr >= 2010 && iyr <= 2020) &&
                        Fields.ContainsKey("eyr") && YearPattern.IsMatch(Fields["eyr"]) && int.TryParse(Fields["eyr"], out int eyr) && (eyr >= 2020 && eyr <= 2030) &&
                        IsHeightValid &&
                        Fields.ContainsKey("hcl") && HclPattern.IsMatch(Fields["hcl"]) &&
                        Fields.ContainsKey("ecl") && EclPattern.IsMatch(Fields["ecl"]) &&
                        Fields.ContainsKey("pid") && PidPattern.IsMatch(Fields["pid"]) && Fields["pid"].Length == 9;
                } 
            }

            private bool IsHeightValid { get
                {
                    bool valid = Fields.ContainsKey("hgt");

                    if (valid)
                    {
                        var match = HgtPattern.Match(Fields["hgt"]);
                        if (match.Success)
                        {
                            var height = int.Parse(match.Groups[1].Value);
                            valid = (match.Groups[2].Value == "cm") ? (height >= 150 && height <= 193) : (height >= 59 && height <= 76);
                        } else { valid = false; }
                    }

                    return valid;
                }
            }
            public bool IsValidPassport { get { return IsValidID && Fields.ContainsKey("cid"); } }

            public string ToString()
            {
                return $"{Fields["byr"]},{Fields["iyr"]},{Fields["eyr"]},{Fields["hgt"]},{Fields["hcl"]},{Fields["ecl"]},{Fields["pid"]}";
            }

            public static Passport LoadFromString(string input)
            {
                var fields = input.Split(' ');

                var passport = new Passport();
                passport.Entry = input;
                
                foreach (var field in fields)
                {
                    var temp = field.Split(':');
                    passport.Fields.Add(temp[0], temp[1]);
                }

                return passport;
            }

            public static List<Passport> LoadAllFromFile(string fileName)
            {
                List<Passport> passports = new List<Passport>();
                var contents = File.ReadAllText(fileName, Encoding.UTF8);
                var entries = contents.Split("\r\n\r\n").Select(x => x.Replace("\r\n", " ")).ToList();
                passports = entries.Select(x=> Passport.LoadFromString(x)).ToList();

                return passports;
            }
        }
    }
}
