namespace DentalOffice.Application.Actions;

using DentalOffice.Domain.Entities;

using DentalOffice.Validation;
using DentalOffice.Validation.InputParsers;
using DentalOffice.Validation.Validators;

public class ListConsultationsAction : Action
{
    public static async Task<ActionOptions> Run()
    {
        char option = UserInputHandler.Handle(
                "Apresentar a agenda T-Toda ou P-Período: ",
                new CharParser(),
                new CharAgendaValidator()
                );

        DateTime startDate = DateTime.Today, endDate = DateTime.Today;
        if (option == 'P')
        {
            startDate = UserInputHandler.Handle(
                    "Data inicial [DDMMAAAA]: ",
                    new DateTimeParser(),
                    new DateTimeValidator()
                    );
            endDate = UserInputHandler.Handle(
                    "Data final [DDMMAAAA]: ",
                    new DateTimeParser(),
                    new FinalDateTimeValidator(startDate)
                    );
        }

        /*var consultations = Agenda.Get().Consultations;*/
        Console.WriteLine("--------------------------------------------------------------------------");
        Console.WriteLine(" Data       H.Ini  H.Fim  Tempo  Nome                          Dt.Nasc.");
        Console.WriteLine("--------------------------------------------------------------------------");

        /*foreach (var consultation in consultations)*/
        /*{*/
        /*    if (option == 'P' &&*/
        /*            !(consultation.IsInOrAfter(startDate) && consultation.IsInOrBefore(endDate))*/
        /*        )*/
        /*        continue;*/
        /*    var patient = consultation.Patient;*/
        /*    var timeSchedule = consultation.TimeSchedule;*/
        /**/
        /*    Console.WriteLine($"{timeSchedule.Start:dd/MM/yyyy}  {timeSchedule.Start:HH:mm}  {timeSchedule.End:HH:mm}  {timeSchedule.Duration:hh\\:mm}  {patient.Name.PadRight(30)} {patient.BirthDate:dd/MM/yyyy}");*/
        /*}*/

        Console.WriteLine("--------------------------------------------------------------------------");
        return ActionOptions.ShowConsultationMenu;
    }
}
