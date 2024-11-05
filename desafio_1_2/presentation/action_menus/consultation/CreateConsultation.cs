namespace DentalOffice.Presentation.ActionMenus;

using DentalOffice.Presentation;

using DentalOffice.Validation;
using DentalOffice.Validation.Validators;
using DentalOffice.Validation.Parsers;

public class CreateConsultationMenu : ActionMenu
{
    public static MenuOptions Display()
    {
        String cpf;
        while (true)
        {
            cpf = InputValidator.ValidateInput(
                    "Insira o CPF do paciente: ",
                    new StringParser(),
                    new CPFValidator()
                    );

            if (!Registration.GetRegistration().IsCpfRegistered(cpf))
            {
                Console.WriteLine("Erro: O CPF inserido não foi encontrado na base de dados.");
                continue;
            }

            break;
        }

        DateTime date = InputValidator.ValidateInput(
                "Insira a data da consulta [DDMMAAAA]: ",
                new DateTimeParser(),
                new ConsultationDateTimeValidator()
                );

        TimeSpan startHour = InputValidator.ValidateInput(
                "Insira a hora de início da consulta [HHMM]: ",
                new HourOfTheDayParser(),
                new StartHourValidator()
                );

        TimeSpan endHour = InputValidator.ValidateInput(
                "Insira a hora de fim da consulta [HHMM]: ",
                new HourOfTheDayParser(),
                new FinalHourValidator(startHour)
                );

        var startDate = date.Date.Add(startHour);
        var endDate = date.Date.Add(endHour);

        var patient =
            Registration.GetRegistration().GetPatientByCpf(cpf);
        var interval = new TimeInterval(startDate, endDate);
        // TODO: check if there is overlapping
        var consultation = new Consultation(patient, interval);

        return MenuOptions.DisplayConsultationMenu;
    }
}
