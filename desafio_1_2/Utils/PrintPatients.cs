namespace DentalOffice.Utils;

using System.Collections.ObjectModel;
using DentalOffice.Domain;

public class PatientsPrinter
{
  private static void PrintDelimiter() =>
    Console.WriteLine("-------------------------------------------------------------------");

  public static void Print(ReadOnlyCollection<Patient> patients)
  {
    PrintDelimiter();
    Console.WriteLine(" CPF             Nome                          Dt.Nasc.     Idade ");
    PrintDelimiter();
    foreach (var patient in patients)
    {
      Console.WriteLine($"{patient.CPF.PadRight(15)} {patient.Name.PadRight(30)} {patient.BirthDate:dd/MM/yyyy}  {patient.Age,3}");

      if (patient.Consultation is not null)
      {
        var consultation = patient.Consultation;
        Console.WriteLine("                Agendado para: {0:dd/MM/yyyy}", consultation.TimeSchedule.Start);
        Console.WriteLine("                {0:HH:mm} às {1:HH:mm}",
            consultation.TimeSchedule.Start, consultation.TimeSchedule.End);
      }
    }

    PrintDelimiter();
  }
}
