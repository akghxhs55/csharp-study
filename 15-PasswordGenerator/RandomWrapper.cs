public class RandomWrapper : IRandom
{
    private readonly Random _rand = new();

    public int Next(int minValue, int maxValue)
    {
        return _rand.Next(minValue, maxValue);
    }

    public int Next(int maxValue)
    {
        return _rand.Next(maxValue);
    }
}