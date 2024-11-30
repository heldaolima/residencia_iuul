namespace DentalOffice.Application.Actions;

using DentalOffice.Domain.Entities;
using DentalOffice.Validation;
using DentalOffice.Validation.InputParsers;
using DentalOffice.Validation.Validators;

public class CancelConsultationAction : Action
{
    public static async Task<ActionOptions> Run()
    {
        String cpf = UserInputHandler.Handle(
                "CPF: ",
                new StringParser(),
                new IsPatientRegisteredValidator()
                );

        /*var registration = Registration.Get();*/
        /*var patient = registration.GetPatientByCpf(cpf);*/
        /*if (patient is null)*/
        /*    return ActionOptions.ShowConsultationMenu;*/

        /*if (!patient.HasFutureConsultation())*/
        /*{*/
        /*    Console.WriteLine("Erro: o paciente não tem consulta agendada.");*/
        /*    return ActionOptions.ShowConsultationMenu;*/
        /*}*/

        DateTime startDate;

        while (true)
        {
            DateTime baseDate = UserInputHandler.Handle(
                    "Data da consulta [DDMMAAAA]: ",
                    new DateTimeParser(),
                    new ConsultationDateTimeValidator()
                    );

            TimeSpan startHour = UserInputHandler.Handle(
                    "Hora inicial [HHMM]: ",
                    new HourOfTheDayParser(),
                    new StartHourValidator(baseDate)
                    );

            startDate = baseDate.Date.Add(startHour);
            if (startDate < DateTime.Now)
            {
                Console.WriteLine("Erro: consultas só podem ser agendadas para o futuro.");
                continue;
            }
            break;
        }

        /*if (patient.IsTheSameConsultation(startDate) && patient.Consultation is not null)*/
        /*{*/
        /*    Agenda.Get().RemoveConsultation(patient.Consultation);*/
        /*    Console.WriteLine("Agendamento cancelado com sucesso!");*/
        /*}*/
        /*else*/
        /*    Console.WriteLine("Erro: agendamento não encontrado.");*/

        return ActionOptions.ShowConsultationMenu;
    }
}
