using System;

namespace AdventOfCode2020;
internal class Day9
{
    private static long[] LoadAllFromFile(string fileName)
    {
        return File.ReadAllLines(fileName).Select(x=> long.Parse(x)).ToArray();        
    }

    public static void Process()
    {
        var numbers = LoadAllFromFile(@"Inputs\Day9.txt");
        Part2(numbers);
    }

    private static void Part1(long[] numbers)
    {
        for (int i = 25; i < numbers.Length; i++)
        {
            if (!IsValidNumber(numbers, i))
            {
                Console.WriteLine($"The first invalid number is {numbers[i]}");
            }
        }
    }

    private static void Part2(long[] numbers)
    {
        long target = 530627549;
        long sum = 0;

        for (int i = 0; i < numbers.Length; i++)
        {
            sum = numbers[i];
            for (int j = i + 1; j < numbers.Length; j++)
            {
                sum += numbers[j];
                if (target == sum)
                {
                    var set = numbers.Skip(i).Take(j-i).ToList();
                    Console.WriteLine($"The sum = {set.Min() + set.Max()}");


                } else
                {
                    if (sum > target)
                        continue; 
                }                    
            }
        }
    }

    private static bool IsValidNumber(long[] numbers, int index)
    {
        var target = numbers[index];
        int start = index - 25;

        for (int i = start; i < index; i++)
        {
            var num1 = numbers[i];
            for (int j = i+1; j < index; j++)
            {
                if (target == num1+numbers[j])
                    return true;
            }
        }
        return false;
    }
}
