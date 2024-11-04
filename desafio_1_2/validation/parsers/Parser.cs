namespace DentalOffice.Validation.Parsers;

public interface Parser<T>
{
  abstract public (T, bool) Parse(String value);
}
