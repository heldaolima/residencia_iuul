namespace DentalOffice.Validation.InputParsers;

public class HourOfTheDayParser : InputParser<TimeSpan>
{
  public (TimeSpan, bool) Parse(String value)
  {
    if (value.Length != 4)
      return (TimeSpan.Zero, false);

    int hours, minutes;
    bool valid;

    String hoursString = value.Substring(0, 2);
    valid = int.TryParse(hoursString, out hours);
    if (!valid || (hours < 0 || hours > 23))
      return (TimeSpan.Zero, false);

    String minutesString = value.Substring(2, 2);
    valid = int.TryParse(minutesString, out minutes);
    if (!valid || (minutes < 0 || minutes > 59))
      return (TimeSpan.Zero, false);

    return (new TimeSpan(hours, minutes, 0), true);
  }

  public String ParseError() => "Entrada inválida para horário.";
}
