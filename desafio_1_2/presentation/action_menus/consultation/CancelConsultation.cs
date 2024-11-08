namespace DentalOffice.Presentation.ActionMenus;

using DentalOffice.Domain;
using DentalOffice.Validation;
using DentalOffice.Validation.Parsers;
using DentalOffice.Validation.Validators;

public class CancelConsultationMenu : ActionMenu
{
    public static MenuOptions Display()
    {
        String cpf = InputValidator.ValidateInput(
                "CPF: ",
                new StringParser(),
                new IsPatientRegisteredValidator()
                );

        var registration = Registration.Get();
        var patient = registration.GetPatientByCpf(cpf);
        if (patient is null)
            return MenuOptions.DisplayConsultationMenu;

        if (!patient.HasFutureConsultation())
        {
            Console.WriteLine("Erro: o paciente não tem consulta agendada.");
            return MenuOptions.DisplayConsultationMenu;
        }

        DateTime baseDate = InputValidator.ValidateInput(
                    "Data da consulta [DDMMAAAA]: ",
                    new DateTimeParser(),
                    new ConsultationDateTimeValidator()
                    );

        TimeSpan startHour = InputValidator.ValidateInput(
                    "Hora inicial [HHMM]: ",
                    new HourOfTheDayParser(),
                    new StartHourValidator(baseDate)
                    );

        DateTime startDate = baseDate.Date.Add(startHour);
        if (patient.IsTheSameConsultation(startDate) && patient.Consultation is not null)
        {
            Agenda.Get().RemoveConsultation(patient.Consultation);
            Console.WriteLine("Agendamento cancelado com sucesso!");
        }

        Console.WriteLine("Erro: agendamento não encontrado.");

        return MenuOptions.DisplayConsultationMenu;
    }
}
