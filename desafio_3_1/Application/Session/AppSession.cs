namespace DentalOffice.Application;

using Application.DBSession;
using Domain.Interfaces;
using Infra.Repositories;

public class AppSession
{
  public readonly IPatientRepository PatientRepository;
  public readonly IConsultationRepository ConsultationRepository;

  private AppSession(IPatientRepository patientRepo, IConsultationRepository consultationRep)
  {
    PatientRepository = patientRepo;
    ConsultationRepository = consultationRep;
  }

  public static AppSession InitSession()
  {
    return new AppSession(
        new PatientRepository(DbSession.Db),
        new ConsultationRepository(DbSession.Db)
    );
  }
}


