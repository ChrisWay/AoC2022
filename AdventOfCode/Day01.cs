namespace AdventOfCode;

public class Day01 : BaseDay
{
    private readonly string[] _input;

    public Day01()
    {
        _input = File.ReadAllLines(InputFilePath);
    }

    public override ValueTask<string> Solve_1()
    {
        var totals = GetTotals();

        return ValueTask.FromResult(totals.Max().ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        var totals = GetTotals();

        var topThreeTotal = totals
            .OrderByDescending(x => x)
            .Take(3)
            .Sum();

        return ValueTask.FromResult(topThreeTotal.ToString());
    }

    List<int> GetTotals()
    {
        var totals = new List<int>(250);
        int runningTotal = 0;

        foreach (var line in _input)
        {
            if (string.IsNullOrEmpty(line))
            {
                totals.Add(runningTotal);
                runningTotal = 0;
                continue;
            }

            runningTotal += int.Parse(line);
        }

        return totals;
    }
}
