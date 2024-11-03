namespace DentalOffice.Validators;

public interface Validator<T>
{
  abstract public (T, bool) Validate(String value);
}
