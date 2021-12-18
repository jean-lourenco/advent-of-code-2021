using System.Diagnostics;

var measurements = File.ReadAllLines("input.txt").Select(int.Parse).ToArray();
var part1 = Solver.Part1(measurements);
var part2 = Solver.Part2(measurements);

Console.WriteLine("Advent of Code 2021 Day 01");
Console.WriteLine($"Part 1: {part1}");
Console.WriteLine($"Part 2: {part2}");

Debug.Assert(part1 == 1521);
Debug.Assert(part2 == 1543);

public static class Solver
{
    public static int Part1(int[] m)
    {
        var timesIncreased = 0;
        for (var i = 1; i < m.Length; i++)
        {
            if (m[i] > m[i-1])
                timesIncreased++;
        }

        return timesIncreased;
    }

    public static int Part2(int[] m)
    {
        var part = m.Partition(3, 1).Select(x => x.Sum()).ToArray();

        return Part1(part);
    }

    public static IEnumerable<IEnumerable<int>> Partition(this IEnumerable<int> ints, int take, int skip)
    {
        var source = ints;
        while (source.Any())
        {
            yield return source.Take(take);
            source = source.Skip(skip);
        }
    }

    public static IEnumerable<int> GenerateNumbers()
    {
        for (var i = 0; i < 10; i++)
        {
            yield return i;
        }
    }
}