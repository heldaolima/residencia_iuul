namespace DentalOffice.Validation.Validators;

public interface Validator<T>
{
  Task<String?> Validate(T value);
}
