namespace DentalOffice.Validation.Parsers;

using System.Globalization;

public class DateTimeParser : Parser<DateTime>
{
  public (DateTime, bool) Parse(String value)
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

  public String ParseError() => "Entrada inválida para data.";
}
