namespace DentalOffice.Validation.Validators;

public class NameValidator : Validator<String>
{
  private int MinChars = 5;

  public bool Validate(String value) => value.Length >= MinChars;
}
