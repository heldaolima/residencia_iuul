namespace Conversor.Domain.Helpers;

public class ConversionResponse
{
  public readonly double ConversionRate;

  public ConversionResponse(double rate)
  {
    ConversionRate = rate;
  }

}
