namespace DentalOffice.Presentation.ActionMenus;

using DentalOffice.Validation;
using DentalOffice.Validation.Parsers;
using DentalOffice.Validation.Validators;

class DateTimeValidator : Validator<DateTime>
{
    public String? Validate(DateTime date) => null;
}

class FinalDateTimeValidator : Validator<DateTime>
{
    private DateTime Start;
    public FinalDateTimeValidator(DateTime start)
    {
        Start = start;
    }
    public String? Validate(DateTime date)
    {
        if (date < Start)
            return "Erro: a data final não pode ser anterior à inicial.";
        return null;
    }
}

public class ListConsultationsInsidePeriod : ActionMenu
{
    public static MenuOptions Display()
    {
        var startDate = InputValidator.ValidateInput(
                "Data inicial [DDMMAAAA]: ",
                new DateTimeParser(),
                new DateTimeValidator()
                );

        var endDate = InputValidator.ValidateInput(
                "Data final [DDMMAAAA]: ",
                new DateTimeParser(),
                new FinalDateTimeValidator(startDate)
                );

        var consultations = Registration.GetRegistration().Consultations;
        Console.WriteLine("--------------------------------------------------------------------------");
        Console.WriteLine(" Data       H.Ini  H.Fim  Tempo  Nome                          Dt.Nasc.");
        Console.WriteLine("--------------------------------------------------------------------------");

        foreach (var consultation in consultations)
        {
            if (consultation.TimeSchedule.Start.CompareTo(startDate) > 0 && consultation.TimeSchedule.Start.CompareTo(endDate) < 0)
            {
                var patient = consultation.Patient;
                var timeSchedule = consultation.TimeSchedule;

                Console.WriteLine($"{timeSchedule.Start:dd/MM/yyyy}  {timeSchedule.Start:HH:mm}  {timeSchedule.End:HH:mm}  {timeSchedule.Duration:hh\\:mm}  {patient.Name.PadRight(30)} {patient.BirthDate:dd/MM/yyyy}");
            }
        }

        Console.WriteLine("--------------------------------------------------------------------------");
        return MenuOptions.DisplayConsultationMenu;
    }
}
