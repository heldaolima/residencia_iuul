namespace DentalOffice.Validation.Validators;

public class NameValidator : Validator<String>
{
  private int MinChars = 5;

  public String? Validate(String value)
  {
    if (value.Length < MinChars)
      return $"Erro: O nome deve ter no mínimo {MinChars} caracteres.";

    return null;
  }
}
