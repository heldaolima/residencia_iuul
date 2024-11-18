namespace Conversor.Validation.InputParsers;

using System.Globalization;

public class DoubleParser : InputParser<double>
{
  private bool TryParseDouble(String value, out double result)
  {
    if (double.TryParse(value.Replace(".", ","), NumberStyles.Number, new CultureInfo("pt-BR"), out result))
    {
      return true;
    }

    return double.TryParse(value.Replace(",", "."), NumberStyles.Number, CultureInfo.InvariantCulture, out result);
  }

  public (double, bool) Parse(String value)
  {
    double result = 0.0;
    bool success = TryParseDouble(value, out result);

    return (result, success);
  }

  public String ParseError() => "Erro: entrada inválida para valor.";
}
