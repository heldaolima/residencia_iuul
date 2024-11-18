namespace Conversor.Validation.InputParsers;

public interface InputParser<T>
{
  abstract public (T, bool) Parse(String value);
  abstract public String ParseError();
}
