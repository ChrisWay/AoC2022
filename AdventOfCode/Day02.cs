namespace AdventOfCode;

internal class Day02 : BaseDay
{
    private readonly string[] _input;

    public Day02()
    {
        _input = File.ReadAllLines(InputFilePath);
    }

    public override ValueTask<string> Solve_1()
    {
        int totalScore = 0;

        foreach (var game in _input)
        {
            var choices = game.Split(' ').Select(InputToChoice);

            totalScore += (int)choices.Last();
            totalScore += (int)GameResult(choices.First(), choices.Last());
        }

        return ValueTask.FromResult(totalScore.ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        int totalScore = 0;

        foreach (var game in _input)
        {
            var choices = game.Split(' ');
            var elf = choices[0];
            var result = choices[1];
            var myChoice = CalculateMyChoice(InputToChoice(elf), InputToResult(result));

            totalScore += (int)myChoice;
            totalScore += (int)GameResult(InputToChoice(elf), myChoice);

        }

        return ValueTask.FromResult(totalScore.ToString());
    }

    Choice CalculateMyChoice(Choice elf, Result requiredResult)
    {
        if(requiredResult == Result.Win)
        {
            switch (elf)
            {
                case Choice.Rock:
                    return Choice.Paper;
                case Choice.Paper:
                    return Choice.Scissors;
                case Choice.Scissors:
                    return Choice.Rock;
            }
        } 
        else if(requiredResult == Result.Lose)
        {
            switch (elf)
            {
                case Choice.Rock:
                    return Choice.Scissors;
                case Choice.Paper:
                    return Choice.Rock;
                case Choice.Scissors:
                    return Choice.Paper;
            }
        }

        return elf;
    }

    Result GameResult(Choice elf, Choice me)
    {
        if(elf == me)
        {
            return Result.Draw;
        }

        if((elf == Choice.Rock && me == Choice.Paper) | (elf == Choice.Paper && me == Choice.Scissors) | (elf == Choice.Scissors && me == Choice.Rock))
        {
            return Result.Win;
        }

        return Result.Lose;
    }

    Choice InputToChoice(string input)
    {
        switch (input)
        {
            case "A":
            case "X":
                return Choice.Rock;

            case "B":
            case "Y":
                return Choice.Paper;
            default:
                return Choice.Scissors;
        }
    }

    Result InputToResult(string input)
    {
        switch (input) 
        {
            case "X":
                return Result.Lose;
            case "Y":
                return Result.Draw;
            case "Z":
                return Result.Win;
        }

        throw new InvalidOperationException();
    }

    enum Result {
        Win = 6,
        Lose = 0,
        Draw = 3
    }

    enum Choice
    {
        Rock = 1,
        Paper = 2,
        Scissors = 3
    }
}

