namespace DentalOffice.Application.Actions;

using DentalOffice.Domain;
using DentalOffice.Utils;

using DentalOffice.Validation;
using DentalOffice.Validation.Validators;
using DentalOffice.Validation.InputParsers;

public class CreateConsultationAction : Action
{
    public static ActionOptions Run()
    {
        String cpf = UserInputHandler.Handle(
                "CPF: ",
                new StringParser(),
                new IsPatientRegisteredValidator()
                );

        var registration = Registration.Get();
        var agenda = Agenda.Get();

        var patient = registration.GetPatientByCpf(cpf);
        if (patient is null)
            return ActionOptions.ShowConsultationMenu;

        if (patient.HasFutureConsultation())
        {
            Console.WriteLine("Erro: paciente está agendado.");
            return ActionOptions.ShowConsultationMenu;
        }

        DateTime baseDate, startDate, endDate;
        TimeSpan startHour, endHour;
        TimeInterval consultationTime;

        while (true)
        {
            baseDate = UserInputHandler.Handle(
                    "Data da consulta [DDMMAAAA]: ",
                    new DateTimeParser(),
                    new ConsultationDateTimeValidator()
                    );

            startHour = UserInputHandler.Handle(
                    "Hora inicial [HHMM]: ",
                    new HourOfTheDayParser(),
                    new StartHourValidator(baseDate)
                    );

            startDate = baseDate.Date.Add(startHour);

            endHour = UserInputHandler.Handle(
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

        return ActionOptions.ShowConsultationMenu;
    }
}
