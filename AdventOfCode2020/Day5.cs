using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020
{
    internal class Day5
    {
        public static void Process()
        {

        }

        internal class SeatSpace
        {
            public int RowLower { get; set; }
            public int RowUpper { get; set; }

            public int SeatLower { get; set; }
            public int SeatUpper { get; set; }

            public int Row { get; set; }
            public int Seat { get; set; }
            
            public SeatSpace NarrowDown(SeatSpace s, string key)
            {
                var newSpace = new SeatSpace();

                switch (key)
                {
                    case "F":
                        if (s.RowUpper - s.RowLower == 1)
                        {
                            newSpace.Row = s.RowLower;
                        } else
                        {
                            newSpace.RowUpper = s.RowLower;
                            newSpace.RowUpper = (s.RowUpper - 1) / 2;
                        }
                        break;                        
                    case "B":
                        if (s.RowUpper - s.RowLower == 1)
                        {
                            newSpace.Row = s.RowUpper;
                        }
                        else
                        {
                            newSpace.RowUpper = (s.RowUpper - 1) / 2;
                            newSpace.RowUpper = s.RowUpper;
                        }
                        break;
                    case "L":
                        if (s.SeatUpper - s.SeatLower == 1)
                        {
                            newSpace.Seat = s.SeatLower;
                        }
                        else
                        {
                            newSpace.SeatUpper = s.SeatLower;
                            newSpace.SeatUpper = (s.SeatUpper - 1) / 2;
                        }
                        break;
                    case "R":
                        if (s.SeatUpper - s.SeatLower == 1)
                        {
                            newSpace.Seat = s.SeatUpper;
                        }
                        else
                        {
                            newSpace.SeatUpper = (s.SeatUpper - 1) / 2;
                            newSpace.SeatUpper = s.SeatUpper;
                        }
                        break;
                }

                return newSpace;

            }

            public static SeatSpace InitSpace()
            {
                return new SeatSpace { RowLower = 0, RowUpper = 127, SeatLower = 0, SeatUpper = 7 , Row = -1, Seat = -1};
            }
        }
    }
}
