namespace DentalOffice.Application.Actions;

public enum ActionOptions
{
  ShowMenuAgain,
  Terminate,
  ShowMainMenu,

  ShowPatientsMenu,
  GoToRegisterPatientAction,
  GoToExcludePatientAction,
  GoToListPatientsByCpfAction,
  GoToListPatientsByNameAction,

  ShowConsultationMenu,
  GoToCreateConsultationAction,
  GoToCancelConsultationAction,
  GoToListConsultationsAction,
}
