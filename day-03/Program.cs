using System.Diagnostics;
using System.IO;

var part1 = Solver.Part1();
var part2 = Solver.Part2();

Console.WriteLine("Advent of Code 2021 Day 03");
Console.WriteLine($"Part 1: {part1}");
Console.WriteLine($"Part 2: {part2}");

Debug.Assert(part1 == 852500);
// Debug.Assert(part2 == 1727785422);

public static class Solver
{
    public static int Part1()
    {
        using var file = System.IO.File.OpenRead("input.txt");
        var gammaRate = "";
        var epsilonRate = "";
        for (var i = 0; i < 12; i++)
        {
            var zeroCount = 0;
            var oneCount = 0;

            for (var j = 0;;j++)
            {
                var offset = 14 * j + i;

                if (offset >= file.Length)
                    break;

                file.Seek(offset, SeekOrigin.Begin);
                var b = file.ReadByte();
                if (b == 48) 
                    zeroCount++;
                else
                    oneCount++;
            }

            if (zeroCount > oneCount)
            {
                gammaRate += "0";
                epsilonRate += "1";
            }
            else
            {
                gammaRate += "1";
                epsilonRate += "0";
            }
        }

        return Convert.ToInt32(gammaRate, 2) * Convert.ToInt32(epsilonRate, 2);
    }

    public static int Part2()
    {
        static int Search(IEnumerable<string> b, int index, bool selectMost, string tieBreaker)
        {
            if (b.Count() == 1)
                return Convert.ToInt32(b.Single(), 2);

            var zeroCount = b.Where(x => x[index] == '0').Count();
            var oneCount = b.Count() - zeroCount;

            if (selectMost)
            {
                if (zeroCount > oneCount)

            }
        }
    }
}