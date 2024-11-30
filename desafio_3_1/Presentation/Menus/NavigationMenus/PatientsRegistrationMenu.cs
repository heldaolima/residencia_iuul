namespace DentalOffice.Presentation.Menus;

using DentalOffice.Application.Actions;

class PatientRegistrationMenu : NavigationMenu
{
  public PatientRegistrationMenu()
  {
    options.Add("Cadastrar novo paciente");
    options.Add("Excluir paciente");
    options.Add("Listar pacientes (ordenado por CPF)");
    options.Add("Listar pacientes (ordenado por nome)");
    options.Add("Voltar p/ menu principal");
  }

  public override ActionOptions ParseInput(int option)
  {
    return (option) switch
    {
      1 => ActionOptions.GoToRegisterPatientAction,
      2 => ActionOptions.GoToExcludePatientAction,
      3 => ActionOptions.GoToListPatientsByCpfAction,
      4 => ActionOptions.GoToListPatientsByNameAction,
      5 => ActionOptions.ShowMainMenu,
      _ => ActionOptions.ShowMenuAgain,
    };
  }
}
