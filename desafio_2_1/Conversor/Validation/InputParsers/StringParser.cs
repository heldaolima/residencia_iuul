namespace Conversor.Validation.InputParsers;

public class StringParser : InputParser<String>
{
  public (String, bool) Parse(String value)
  {
    if (value is not null)
      return (value.ToUpper(), true);
    return ("", false);
  }

  public String ParseError() => "Entrada inválida.";
}
