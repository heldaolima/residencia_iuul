namespace DentalOffice.Validation.Validators;

public class NameValidator : Validator<String>
{
  private int MinChars = 5;

  public Task<String?> Validate(String value)
  {
    if (value.Length < MinChars)
      return Task.FromResult<string?>($"Erro: O nome deve ter no mínimo {MinChars} caracteres.");

    return Task.FromResult<string?>(null);
  }
}
