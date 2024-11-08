namespace DentalOffice.Validation.Validators;

public class PatientForConsultationValidator : Validator<String>
{
  public String? Validate(String cpf)
  {
    String? patientError = new IsPatientRegisteredValidator().Validate(cpf);
    if (patientError is not null)
      return patientError;

    var patient = Registration.GetRegistration().GetPatientByCpf(cpf);
    if (patient is not null && patient.HasFutureConsultation())
      return "Erro: o paciente já está agendado.";

    return null;
  }
}
