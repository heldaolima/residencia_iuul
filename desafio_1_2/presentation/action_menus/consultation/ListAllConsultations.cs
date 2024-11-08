namespace DentalOffice.Presentation.ActionMenus;

public class ListAllConsultations : ActionMenu
{
    public static MenuOptions Display()
    {
        var consultations = Registration.GetRegistration().Consultations;
        Console.WriteLine("--------------------------------------------------------------------------");
        Console.WriteLine(" Data       H.Ini  H.Fim  Tempo  Nome                          Dt.Nasc.");
        Console.WriteLine("--------------------------------------------------------------------------");

        foreach (var consultation in consultations)
        {
            var patient = consultation.Patient;
            var timeSchedule = consultation.TimeSchedule;

            Console.WriteLine($"{timeSchedule.Start:dd/MM/yyyy}  {timeSchedule.Start:HH:mm}  {timeSchedule.End:HH:mm}  {timeSchedule.Duration:hh\\:mm}  {patient.Name.PadRight(30)} {patient.BirthDate:dd/MM/yyyy}");
        }

        Console.WriteLine("--------------------------------------------------------------------------");
        return MenuOptions.DisplayConsultationMenu;
    }
}
