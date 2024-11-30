namespace DentalOffice.Application.Actions;

using Domain.Interfaces;

using Validation;
using Validation.InputParsers;
using Validation.Validators;

public class ListConsultationsAction : Action
{
    private IConsultationRepository consultationRepository;

    public ListConsultationsAction(IConsultationRepository cRepo)
    {
        consultationRepository = cRepo;
    }

    public async Task<ActionOptions> Run()
    {
        char option = await UserInputHandler.Handle(
                "Apresentar a agenda T-Toda ou P-Período: ",
                new CharParser(),
                new CharAgendaValidator()
                );

        DateTime startDate = DateTime.Today, endDate = DateTime.Today;
        if (option == 'P')
        {
            startDate = await UserInputHandler.Handle(
                    "Data inicial [DDMMAAAA]: ",
                    new DateTimeParser(),
                    new DateTimeValidator()
                    );
            endDate = await UserInputHandler.Handle(
                    "Data final [DDMMAAAA]: ",
                    new DateTimeParser(),
                    new FinalDateTimeValidator(startDate)
                    );
        }

        var consultations = await consultationRepository.GetAll();

        Console.WriteLine("--------------------------------------------------------------------------");
        Console.WriteLine(" Data       H.Ini  H.Fim  Tempo  Nome                          Dt.Nasc.");
        Console.WriteLine("--------------------------------------------------------------------------");

        foreach (var consultation in consultations)
        {
            if (option == 'P' &&
                    !(consultation.IsInOrAfter(startDate) && consultation.IsInOrBefore(endDate))
                )
                continue;
            var patient = consultation.Patient;
            var timeSchedule = consultation.TimeSchedule;

            Console.WriteLine($"{timeSchedule.Start:dd/MM/yyyy}  {timeSchedule.Start:HH:mm}  {timeSchedule.End:HH:mm}  {timeSchedule.Duration:hh\\:mm}  {patient.Name.PadRight(30)} {patient.BirthDate:dd/MM/yyyy}");
        }

        Console.WriteLine("--------------------------------------------------------------------------");
        return ActionOptions.ShowConsultationMenu;
    }
}
