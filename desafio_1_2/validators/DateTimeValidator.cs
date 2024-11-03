namespace DentalOffice.Validators;
using System.Globalization;

public class DateTimeValidator : Validator<DateTime>
{
  public (DateTime, bool) Validate(String value)
  {
    try
    {
      DateTime date =
        DateTime.ParseExact(value, "ddMMyyyy", new CultureInfo("pt-BR"));

      return (date, true);
    }
    catch (FormatException)
    {
      return (new DateTime(), false);
    }
  }
}
