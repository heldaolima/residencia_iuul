// See https://aka.ms/new-console-template for more information
namespace DentalOffice;
using DentalOffice.Presentation;

class App
{
  public static void Main()
  {
    var mainMenu = new MainMenu();
    var agendaMenu = new AgendaMenu();
    var patientRegistrationMenu = new PatientRegistrationMenu();

    Menu currentMenu = mainMenu;
    while (true)
    {
      int opt = currentMenu.Display();
      Console.WriteLine($"Opção: {opt}");
      if (opt == -1)
      {
        break;
      }
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
