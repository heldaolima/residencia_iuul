namespace DentalOffice.Application.Actions;

using Domain.Entities;
using Domain.Interfaces;

using Validation;
using Validation.Validators;
using Validation.InputParsers;

public class CreateConsultationAction : Action
{
    private IPatientRepository patientRepository;
    private IConsultationRepository consultationRepository;

    public CreateConsultationAction(IPatientRepository pRepo, IConsultationRepository cRepo)
    {
        patientRepository = pRepo;
        consultationRepository = cRepo;
    }

    public async Task<ActionOptions> Run()
    {
        String cpf = await UserInputHandler.Handle(
                "CPF: ",
                new StringParser(),
                new IsPatientRegisteredValidator(patientRepository)
                );


        var patient = await patientRepository.GetPatientByCpf(cpf);
        if (patient is null)
            return ActionOptions.ShowConsultationMenu;

        if (patient.HasFutureConsultation())
        {
            Console.WriteLine("Erro: paciente está agendado.");
            return ActionOptions.ShowConsultationMenu;
        }

        DateTime startDate, endDate;
        TimeInterval consultationTime;
        while (true)
        {
            DateTime baseDate = await UserInputHandler.Handle(
                    "Data da consulta [DDMMAAAA]: ",
                    new DateTimeParser(),
                    new ConsultationDateTimeValidator()
                    );

            TimeSpan startHour = await UserInputHandler.Handle(
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

            TimeSpan endHour = await UserInputHandler.Handle(
                    "Hora final [HHMM]: ",
                    new HourOfTheDayParser(),
                    new FinalHourValidator(startHour)
                    );

            endDate = baseDate.Date.Add(endHour);

            consultationTime = new TimeInterval(startDate, endDate);
            if (await consultationRepository.DoesConsultationTimeOverlaps(consultationTime))
            {
                Console.WriteLine("Erro: já existe uma consulta agendada para este horário.");
                continue;
            }
            break;
        }

        await consultationRepository.AddConsultation(new Consultation(patient, consultationTime));

        Console.WriteLine("Consulta agendada com sucesso!");

        return ActionOptions.ShowConsultationMenu;
    }
}
