namespace AdventOfCode;

public class Day01 : BaseDay
{
    private readonly string _input;

    public Day01()
    {
        _input = File.ReadAllText(InputFilePath);
    }

    public override ValueTask<string> Solve_1()
    {
        var lines = _input.Split(Environment.NewLine, StringSplitOptions.None);
        var totals = new List<int>();
        int runningTotal = 0;

        foreach (var line in lines)
        {
            if (string.IsNullOrEmpty(line))
            {
                totals.Add(runningTotal);
                runningTotal = 0;
                continue;
            }

            runningTotal += int.Parse(line);
        }

        return ValueTask.FromResult(totals.Max().ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        var lines = _input.Split(Environment.NewLine, StringSplitOptions.None);
        var totals = new List<int>();
        int runningTotal = 0;

        foreach (var line in lines)
        {
            if (string.IsNullOrEmpty(line))
            {
                totals.Add(runningTotal);
                runningTotal = 0;
                continue;
            }

            runningTotal += int.Parse(line);
        }

        var topThreeTotal = totals
            .OrderByDescending(x => x)
            .Take(3)
            .Sum();

        return ValueTask.FromResult(topThreeTotal.ToString());
    }
}
