namespace DentalOffice.Validation.Validators;

public class StartHourValidator : Validator<TimeSpan>
{
  public String? Validate(TimeSpan value)
  {
    if (value.Minutes % 15 != 0)
      return "Erro: horários de consulta devem ser definidos de 15 em 15 minutos.";

    if (value.Hours < 8 || value.Hours > 19)
      return "Erro: horário fora do horário de funcionamento do consultório (das 8h00 às 19h00).";

    return null;
  }
}
