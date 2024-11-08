namespace DentalOffice.Presentation.ActionMenus;

using DentalOffice.Presentation;
using DentalOffice.Domain;
using DentalOffice.Utils;

using DentalOffice.Validation;
using DentalOffice.Validation.Validators;
using DentalOffice.Validation.Parsers;

public class CreateConsultationMenu : ActionMenu
{
    public static MenuOptions Display()
    {
        String cpf = InputValidator.ValidateInput(
                "CPF: ",
                new StringParser(),
                new IsPatientRegisteredValidator()
                );

        var registration = Registration.Get();
        var agenda = Agenda.Get();

        var patient = registration.GetPatientByCpf(cpf);
        if (patient is null)
            return MenuOptions.DisplayConsultationMenu;

        if (patient.HasFutureConsultation())
        {
            Console.WriteLine("Erro: paciente está agendado.");
            return MenuOptions.DisplayConsultationMenu;
        }

        DateTime baseDate, startDate, endDate;
        TimeSpan startHour, endHour;
        TimeInterval consultationTime;

        while (true)
        {
            baseDate = InputValidator.ValidateInput(
                    "Data da consulta [DDMMAAAA]: ",
                    new DateTimeParser(),
                    new ConsultationDateTimeValidator()
                    );

            startHour = InputValidator.ValidateInput(
                    "Hora inicial [HHMM]: ",
                    new HourOfTheDayParser(),
                    new StartHourValidator(baseDate)
                    );

            startDate = baseDate.Date.Add(startHour);

            endHour = InputValidator.ValidateInput(
                    "Hora final [HHMM]: ",
                    new HourOfTheDayParser(),
                    new FinalHourValidator(startHour)
                    );

            endDate = baseDate.Date.Add(endHour);

            consultationTime = new TimeInterval(startDate, endDate);
            if (agenda.DoesConsultationTimeOverlaps(consultationTime))
            {
                Console.WriteLine("Erro: já existe uma consulta agendada para este horário.");
                continue;
            }
            break;
        }

        agenda.AddConsultation(new Consultation(patient, consultationTime));

        Console.WriteLine("Consulta agendada com sucesso!");

        return MenuOptions.DisplayConsultationMenu;
    }
}
