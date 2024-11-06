namespace DentalOffice.Validation.Parsers;

public class CharParser : Parser<char>
{
  public (char, bool) Parse(String value)
  {
    if (value.Length != 1)
      return ('0', false);

    return (char.ToUpper(value[0]), true);
  }

  public String ParseError() => "Erro: Entrada inválida.";
}
