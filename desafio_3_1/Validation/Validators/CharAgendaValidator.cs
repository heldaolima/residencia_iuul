namespace DentalOffice.Validation.Validators;

public class CharAgendaValidator : Validator<char>
{
  public Task<String?> Validate(char value)
  {
    if (value == 'T' || value == 'P')
      return Task.FromResult<string?>(null);

    return Task.FromResult<string?>("Erro: Opção inválida");
  }
}
