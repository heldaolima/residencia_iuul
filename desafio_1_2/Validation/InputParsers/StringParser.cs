namespace DentalOffice.Validation.InputParsers;

public class StringParser : InputParser<String>
{
  public (String, bool) Parse(String value)
  {
    if (value is not null && value.Length > 0)
      return (value, true);
    return ("", false);
  }

  public String ParseError() => "Entrada inválida.";
}
