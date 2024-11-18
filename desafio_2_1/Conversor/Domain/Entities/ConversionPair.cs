namespace Conversor.Domain.Entities;

public class ConversionPair
{
    public String Origin { get; private set; }
    public String Destiny { get; private set; }
    public double Value { get; private set; }

    public ConversionPair(String origin, String destiny, double value)
    {
        Origin = origin;
        Destiny = destiny;
        Value = value;
    }
}


