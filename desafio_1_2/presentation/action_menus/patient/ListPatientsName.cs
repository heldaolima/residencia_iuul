namespace DentalOffice.Presentation.ActionMenus;

public class ListPatientsByNameMenu : ActionMenu
{
    public static MenuOptions Display()
    {
        var patients = Registration.GetRegistration().GetOrderedByName();

        if (patients.Count > 0)
        {
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine(" CPF             Nome                          Dt.Nasc.     Idade ");
            Console.WriteLine("-------------------------------------------------------------------");
            foreach (var patient in patients)
            {
                Console.WriteLine($"{patient.CPF.PadRight(15)} {patient.Name.PadRight(30)} {patient.BirthDate:dd/MM/yyyy}  {patient.Age,3}");

                if (patient.Consultation is not null)
                {
                    var consultation = patient.Consultation;
                    Console.WriteLine("                Agendado para: {0:dd/MM/yyyy}", consultation.TimeSchedule.Start);
                    Console.WriteLine("                {0:HH:mm} às {1:HH:mm}", consultation.TimeSchedule.Start, consultation.TimeSchedule.End);
                }
            }

            Console.WriteLine("-------------------------------------------------------------------");
        }
        return MenuOptions.DisplayPatientsMenu;
    }
}
