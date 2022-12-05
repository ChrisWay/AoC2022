using System.Text;

namespace AdventOfCode;

public class Day03 : BaseDay
{
    private readonly string[] _input;

    public Day03()
    {
        _input = File.ReadAllLines(InputFilePath);
    }

    public override ValueTask<string> Solve_1()
    {
        int prioritySum = 0;

        foreach (var item in _input)
        {
            var compartment1 = item.AsSpan(0, item.Length / 2);
            var compartment2 = item.AsSpan(item.Length / 2, item.Length - item.Length / 2);

            foreach (var c in compartment1)
            {
                if(compartment2.Contains(c))
                {
                    prioritySum += CalculatePriority(c);
                    break;
                }
            }
        }

        return ValueTask.FromResult(prioritySum.ToString());
    }

    int CalculatePriority(char c) => Char.IsUpper(c) ? c - 38 : c - 96;

    public override ValueTask<string> Solve_2()
    {
        int prioritySum = 0;
        int group = 0;

        while(true)
        {
            var rucksacks = _input.Skip(3 * group).Take(3);

            if(!rucksacks.Any())
            {
                break;
            }

            //TODO Make this generic to work for any group size.

            var rucksack1 = rucksacks.ElementAt(0).AsSpan();
            var rucksack2 = rucksacks.ElementAt(1).AsSpan();
            var rucksack3 = rucksacks.ElementAt(2).AsSpan();

            foreach (var c in rucksack1)
            {
                if(rucksack2.Contains(c) && rucksack3.Contains(c))
                {
                    prioritySum += CalculatePriority(c);
                    break;
                }
            }

            group++;
        }

        return ValueTask.FromResult(prioritySum.ToString());
    }
}