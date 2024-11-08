namespace DentalOffice.Validation.Validators;

using DentalOffice.Domain;

public class PatientForConsultationValidator : Validator<String>
{
  public String? Validate(String cpf)
  {
    String? patientError = new IsPatientRegisteredValidator().Validate(cpf);
    if (patientError is not null)
      return patientError;

    var patient = Registration.Get().GetPatientByCpf(cpf);
    if (patient is not null && patient.HasFutureConsultation())
      return "Erro: o paciente já está agendado.";

    return null;
  }
}
