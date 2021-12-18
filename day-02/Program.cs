using System.Diagnostics;

var directions = File.ReadAllLines("input.txt").Select(x => x.Split(' ')).ToArray();
var part1 = Solver.Part1(directions);
var part2 = Solver.Part2(directions);

Console.WriteLine("Advent of Code 2021 Day 02");
Console.WriteLine($"Part 1: {part1}");
Console.WriteLine($"Part 2: {part2}");

Debug.Assert(part1 == 1840243);
Debug.Assert(part2 == 1727785422);

public static class Solver
{
    public static int Part1(string[][] directions)
    {
        var upwards = directions.Where(x => x[0][0] == 'u').Sum(x => int.Parse(x[1]));
        var downwards = directions.Where(x => x[0][0] == 'd').Sum(x => int.Parse(x[1]));
        var horizontal = directions.Where(x => x[0][0] == 'f').Sum(x => int.Parse(x[1]));

        return Math.Abs(upwards - downwards) * horizontal;
    }

    public static int Part2(string[][] directions)
    {
        int aim = 0;
        int depth = 0;
        int distance = 0;

        foreach (var dir in directions)
        {
            switch (dir[0][0])
            {
                case 'f':
                    var d = int.Parse(dir[1]);
                    distance += d;
                    depth += d * aim;
                    break;
                case 'd':
                    aim += int.Parse(dir[1]);
                    break;
                default: 
                    aim -= int.Parse(dir[1]);
                    break;
            };
        }

        return depth * distance;
    }
}