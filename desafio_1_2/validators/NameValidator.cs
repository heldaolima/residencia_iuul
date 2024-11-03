namespace DentalOffice.Validators;

public class NameValidator : Validator<String>
{
  public (String, bool) Validate(String value)
  {
    if (value.Length < 5)
    {
      return ("", false);
    }
    return (value, true);
  }
}
