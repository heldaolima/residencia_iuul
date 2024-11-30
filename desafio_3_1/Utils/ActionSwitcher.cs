namespace DentalOffice.Utils;

using Application.Actions;
using Application;

public class ActionSwitcher
{
  public static Action GetAction(ActionOptions request, AppSession session)
  {
    return request switch
    {
      ActionOptions.GoToRegisterPatientAction => new CreatePatientAction(session.PatientRepository),
      ActionOptions.GoToExcludePatientAction => new DeletePatientAction(session.PatientRepository, session.ConsultationRepository),
      ActionOptions.GoToListPatientsByCpfAction => new ListPatientsByCpfAction(session.PatientRepository),
      ActionOptions.GoToListPatientsByNameAction => new ListPatientsByNameAction(session.PatientRepository),
      ActionOptions.GoToCreateConsultationAction => new CreateConsultationAction(session.PatientRepository, session.ConsultationRepository),
      ActionOptions.GoToCancelConsultationAction => new CancelConsultationAction(session.PatientRepository, session.ConsultationRepository),
      ActionOptions.GoToListConsultationsAction => new ListConsultationsAction(session.ConsultationRepository),
    };

  }
}
