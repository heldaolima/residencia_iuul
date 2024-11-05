namespace DentalOffice.Validation.Validators;


public class ConsultationDateTimeValidator : Validator<DateTime>
{
  public String? Validate(DateTime value)
  {
    // TODO: check if value > today (ou esperar ter o timespan)
    // TODO: check if patient already has a consultation
    DateTime today = DateTime.Today;
    /*today.Hour = 1;*/
    return null;

  }

}
