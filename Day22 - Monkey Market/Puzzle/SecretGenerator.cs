namespace AdventOfCode.Year2024.Day22.Puzzle;

internal sealed class SecretGenerator(int initialSecret)
{
    private int _currentSecret = initialSecret;

    public int CurrentSecret => _currentSecret;

    public int CycleSecret(int cycles)
    {
        for (int i = 0; i < cycles; i++)
        {
            NextSecret();
        }

        return _currentSecret;
    }

    public int NextSecret()
    {
        long nextSecret = _currentSecret;

        nextSecret = Mix(nextSecret, nextSecret * 64);
        nextSecret = Prune(nextSecret);

        nextSecret = Mix(nextSecret, nextSecret / 32);
        nextSecret = Prune(nextSecret);

        nextSecret = Mix(nextSecret, nextSecret * 2048);
        nextSecret = Prune(nextSecret);

        _currentSecret = (int)nextSecret;
        return _currentSecret;
    }

    private static long Mix(long value1, long value2)
    {
        return value1 ^ value2;
    }

    private static long Prune(long value)
    {
        return value % 16777216;
    }
}
