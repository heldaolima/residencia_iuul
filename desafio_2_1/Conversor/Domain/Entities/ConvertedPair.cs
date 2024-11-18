namespace Conversor.Domain.Entities;

public class ConvertedPair
{
    private readonly ConversionPair OriginalPair;
    public double NewValue { get; private set; }
    public double ConversionRate { get; private set; }

    public ConvertedPair(ConversionPair pair, double rate)
    {
        OriginalPair = pair;
        ConversionRate = rate;
        NewValue = pair.Value * rate;
    }

    public void PrintConversion()
    {
        Console.WriteLine($"{OriginalPair.Origin} {OriginalPair.Value:F2} => {OriginalPair.Destiny} {NewValue:F2}");
        Console.WriteLine($"Taxa: {ConversionRate:F6}");
    }
}
