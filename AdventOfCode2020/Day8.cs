namespace AdventOfCode2020;

    internal class Day8
    {
        
        record Instruction(string command, int argument);       

        public static void Process()
        {
            int acc = 0, pos = 0;
            var processed = new List<int>();
            var canRun = true;

            var ins = LoadAllFromFile(@"Inputs\Day8.txt");            
            while (canRun)
            {
                if (processed.Contains(pos))
                {
                    canRun = false;
                    break;
                }
                else
                {
                    processed.Add(pos);
                }

                switch (ins[pos].command)
                {
                    case "nop":
                        pos++;
                        break;
                    case "acc":
                        acc += ins[pos].argument;
                        pos++;
                        break;
                    case "jmp":
                        pos += ins[pos].argument;
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine(acc);
        }

        private static Instruction[] LoadAllFromFile(string fileName)
        {
            var contents = File.ReadAllLines(fileName);
            return contents.Select(x => LoadFromString(x)).ToArray();
        }

        private static Instruction LoadFromString(string line)
        {
            var cmd = line.Split(' ');
            return new Instruction(cmd[0], int.Parse(cmd[1]));
        }
    }