namespace DentalOffice.Validation.Validators;

using Domain.Interfaces;
using Domain.Entities;

public class PatientForConsultationValidator : Validator<String>
{
  private readonly IPatientRepository repository;

  public PatientForConsultationValidator(IPatientRepository repo)
  {
    repository = repo;
  }

  public async Task<String?> Validate(String cpf)
  {
    String? patientError = await new IsPatientRegisteredValidator(repository).Validate(cpf);
    if (patientError is not null)
      return patientError;

    var patient = repository.GetPatientByCpf(cpf);
    if (patient is not null)
      // TODO: implement the HasFutureConsultation method
      /*&& patient.HasFutureConsultation())*/
      return "Erro: o paciente já está agendado.";

    return null;
  }
}
