namespace DentalOffice.Validation.Validators;


public class ConsultationDateTimeValidator : Validator<DateTime>
{
  public String? Validate(DateTime value)
  {
    if (value < DateTime.Today)
      return "Erro: não é possível agendar consultas para o passado.";
    return null;
  }
}
