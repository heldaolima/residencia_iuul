namespace DentalOffice.Validation.Parsers;

public class StringParser : Parser<String>
{
  public (String, bool) Parse(String value)
  {
    if (value is not null && value.Length > 0)
      return (value, true);
    return ("", false);
  }

}
