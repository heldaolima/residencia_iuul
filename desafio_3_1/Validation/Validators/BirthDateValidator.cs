namespace DentalOffice.Validation.Validators;

public class BirthDateValidator : Validator<DateTime>
{
  private const int MinAge = 13;

  public Task<String?> Validate(DateTime value)
  {
    var yearsAgo = DateTime.Today.AddYears(-MinAge);
    if (value <= yearsAgo)
      return Task.FromResult<string?>(null);

    return Task.FromResult<string?>($"Erro: paciente deve ter pelo menos {MinAge} anos.");
  }
}
