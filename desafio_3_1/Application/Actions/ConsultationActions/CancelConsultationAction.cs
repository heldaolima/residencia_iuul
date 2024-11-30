namespace DentalOffice.Application.Actions;

using Domain.Interfaces;
using Validation;
using Validation.InputParsers;
using Validation.Validators;

public class CancelConsultationAction : Action
{
    private IPatientRepository patientRepository;
    private IConsultationRepository consultationRepository;

    public CancelConsultationAction(IPatientRepository pRepo, IConsultationRepository cRepo)
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

        if (!patient.HasFutureConsultation())
        {
            Console.WriteLine("Erro: o paciente não tem consulta agendada.");
            return ActionOptions.ShowConsultationMenu;
        }

        DateTime startDate;

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
            break;
        }

        var consultation = patient.GetFutureConsultationIfItStartsOnDate(startDate);
        if (consultation is not null)
        {
            await consultationRepository.RemoveConsultation(consultation);
            Console.WriteLine("Agendamento cancelado com sucesso!");
        }
        else
            Console.WriteLine("Erro: agendamento não encontrado.");

        return ActionOptions.ShowConsultationMenu;
    }
}
