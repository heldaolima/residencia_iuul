namespace DentalOffice.Presentation.StaticMenus;

class PatientRegistrationMenu : Menu
{
  public PatientRegistrationMenu()
  {
    options.Add("Cadastrar novo paciente");
    options.Add("Excluir paciente");
    options.Add("Listar pacientes (ordenado por CPF)");
    options.Add("Listar pacientes (ordenado por nome)");
    options.Add("Voltar p/ menu principal");
  }

  public override MenuOptions ParseInput(int option)
  {
    return (option) switch
    {
      1 => MenuOptions.DisplayRegisterPatientMenu,
      2 => MenuOptions.DisplayExcludePatientMenu,
      3 => MenuOptions.DisplayListPatientsByCpf,
      4 => MenuOptions.DisplayListPatientsByName,
      5 => MenuOptions.GoBackToMainMenu,
      _ => MenuOptions.ShowAgain,
    };
  }
}
