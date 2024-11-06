namespace DentalOffice;

using DentalOffice.Presentation;
using DentalOffice.Presentation.StaticMenus;
using DentalOffice.Presentation.ActionMenus;

class App
{
  public static void Main()
  {
    var mainMenu = new MainMenu();
    var patientRegistrationMenu = new PatientRegistrationMenu();
    var consultationsMenu = new ConsultationsMenu();
    var chooseListConsultations = new ChooseListConsultationsMenu();

    Menu? currentMenu = mainMenu;
    var action = MenuOptions.GoBackToMainMenu;
    while (true)
    {
      currentMenu = action switch
      {
        MenuOptions.GoBackToMainMenu => mainMenu,
        MenuOptions.DisplayPatientsMenu => patientRegistrationMenu,
        MenuOptions.DisplayConsultationMenu => consultationsMenu,
        MenuOptions.DisplayChooseListConsultationsMenu => chooseListConsultations,
        MenuOptions.ShowAgain => currentMenu,
        MenuOptions.Terminate => null,

        _ => currentMenu
      };

      if (action == MenuOptions.Terminate || currentMenu is null)
        break;

      action = currentMenu.Display();

      action = action switch
      {
        MenuOptions.DisplayRegisterPatientMenu => CreatePatientMenu.Display(),
        MenuOptions.DisplayExcludePatientMenu => DeletePatientMenu.Display(),
        MenuOptions.DisplayListPatientsByCpf => ListPatientsByCpfMenu.Display(),
        MenuOptions.DisplayListPatientsByName => ListPatientsByNameMenu.Display(),
        MenuOptions.DisplayCreateConsultationMenu => CreateConsultationMenu.Display(),
        MenuOptions.DisplayCancelConsultationMenu => CancelConsultationMenu.Display(),
        MenuOptions.DisplayListAllConsultations => ListAllConsultations.Display(),
        MenuOptions.DisplayListConsultationsInsidePeriod => ListConsultationsInsidePeriod.Display(),

        _ => action
      };
    }
  }
}

/*
 *
 * Cadastro de Pacientes:
 *    Ler CPF
 *    Ler Nome (5 caracteres)
 *    Ler Data de Nascimento (DDMMAAA)
 *    Solicitar dado novamente caso haja erro
 *    CPF não pode ser repetido
 *    13 anos ou mais no moemento de cadastro
 *
 * Exclusão de Paciente:
 *    Se tiver uma consulta futura agendada, não pode ser excluído
 *    Se tiver uma ou mais consultas passadas, pode ser excluído. Esses agendamentos serão excluídos
 *
 * Agendamento de Consulta:
 *    CPF do paciente: deve existir no cadastro
 *    Data da Consulta: formato DDMMAAAA
 *        Hora inicial e hora final: HHMM
 *        Data da consulta > data atual ou Data == data_atual AND hora inicial > hora atual
 *        Hora final > hora inicial
 *    Um paciente só pode ter um agendamento futuro por vez
 *    Não pode haver sobreposição de agendamentos
 *    Horas iniciais definidas de 15 em 15 minutos
 *    Horários não podem sair do limite [08:00, 19:00]
 *
 *  Cancelamento de agendamento:
 *    CPF do paciente
 *    Data da consulta
 *    Hora inicial
 *    Só pode cancelar agendamento futuro
 *
 *  Listagem dos pacientes
 *    Se o paciente possuir um agendamento futuro, os dados do agendamento são listados abaixo
 *
 *  Listagem da Agenda
 *    Pode ser de toda a agenda ou de toda a agenda de um só período, caso em que deve ser solicitada
 *    a data inicial e a data final
 * */
