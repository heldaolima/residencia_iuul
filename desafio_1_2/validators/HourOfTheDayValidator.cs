namespace DentalOffice.Validators;

public class HourOfTheDayValidator : Validator<TimeSpan>
{

  public (TimeSpan, bool) Validate(String value)
  {
    if (value.Length != 4)
      return (TimeSpan.Zero, false);

    int hours, minutes;
    bool valid;

    String hoursString = value.Substring(0, 2);
    valid = int.TryParse(hoursString, out hours);
    if (!valid)
      return (TimeSpan.Zero, false);

    String minutesString = value.Substring(2, 4);
    valid = int.TryParse(minutesString, out minutes);
    if (!valid)
      return (TimeSpan.Zero, false);

    return (new TimeSpan(hours, minutes, 0), true);
  }
}
