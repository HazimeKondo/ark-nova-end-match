public static class Trails
{
    public const int MaxConservation = 41;
    public const int MaxAttractivity = 113;
    
    private static int EvaluateConservation(int value)
    {
        if (value <= 10)
            return (value - 10) * 2 + 6;

        return (value - 10) * 3 + 6;
    }

    public static int Result(int conservation, int attractivity)
    {
        return attractivity + EvaluateConservation(conservation)-100;
    }
}