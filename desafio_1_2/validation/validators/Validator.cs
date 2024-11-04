namespace DentalOffice.Validation.Validators;

public interface Validator<T>
{
  public abstract bool Validate(T value);
}
