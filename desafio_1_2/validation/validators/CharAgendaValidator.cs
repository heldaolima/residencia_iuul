namespace DentalOffice.Validation.Validators;

public class CharAgendaValidator : Validator<char>
{
  public String? Validate(char value)
  {
    if (value == 'T' || value == 'P')
      return null;
    return "Erro: Opção inválida";
  }
}
