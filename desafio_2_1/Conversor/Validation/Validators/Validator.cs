namespace Conversor.Validation.Validators;

public interface Validator<T>
{
  public abstract String? Validate(T value);
}
