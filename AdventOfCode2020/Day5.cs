using System.Text;

namespace AdventOfCode2020
{
    internal class Day5
    {
        public static void Process()
        {
            Part2();
        }

        private static void Part1()
        {
            var maxSeatId = SeatSpace
                .LoadAllFromFile(@"Inputs\Day5.txt")
                .Select(x => x.SeatID)
                .Max();

            Console.WriteLine(maxSeatId);
        }

        private static void Part2()
        {
            var seats = SeatSpace
                .LoadAllFromFile(@"Inputs\Day5.txt")
                .Select(x => x.Row + "," + x.Seat);

            File.WriteAllLines(@"Inputs\Day5_output.csv", seats);
        }

        internal class SeatSpace
        {
            int RowLower = 0, RowUpper = 127, SeatLower = 0, SeatUpper = 7;

            public int Row { get; set; }
            public int Seat { get; set; }

            public int SeatID { get { return (Row * 8) + Seat; } }

            public SeatSpace()
            {
                Row = -1;
                Seat = -1;
            }
            public SeatSpace(string code)
            {
                NarrowDown(code);
            }

            public void NarrowDown(string code)
            {

                var keys = code.ToCharArray();

                foreach (var key in keys)
                {
                    switch (key.ToString())
                    {
                        case "F":
                            if (RowUpper - RowLower == 1)
                            {
                                Row = RowLower;
                            }
                            else
                            {
                                RowUpper -= (RowUpper + 1 - RowLower) / 2;
                            }
                            break;
                        case "B":
                            if (RowUpper - RowLower == 1)
                            {
                                Row = RowUpper;
                            }
                            else
                            {
                                RowLower += (RowUpper + 1 - RowLower) / 2;
                            }
                            break;
                        case "L":
                            if (SeatUpper - SeatLower == 1)
                            {
                                Seat = SeatLower;
                            }
                            else
                            {
                                SeatUpper -= (SeatUpper + 1 - SeatLower) / 2;
                            }
                            break;
                        case "R":
                            if (SeatUpper - SeatLower == 1)
                            {
                                Seat = SeatUpper;
                            }
                            else
                            {
                                SeatLower += (SeatUpper + 1 - SeatLower) / 2;
                            }
                            break;
                    }
                }
            }

            public static List<SeatSpace> LoadAllFromFile(string fileName)
            {
                var contents = File.ReadAllLines(fileName, Encoding.UTF8);

                var seats = contents.Select(c => new SeatSpace(c)).ToList();

                return seats;
            }
        }
    }
}
