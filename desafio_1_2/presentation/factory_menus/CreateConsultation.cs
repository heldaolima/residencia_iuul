namespace DentalOffice.Presentation.FactoryMenus;

using DentalOffice.Presentation.StaticMenus;
using DentalOffice.Validators;

public class CreateConsultationMenu
{
    public static Menu.MenuOptions Create()
    {
        String patientCpf = InputValidator.ValidateInput(
                "Insira o CPF do paciente: ",
                "Erro: CPF inválido.",
                new CPFValidator()
                );

        var patient =
            Registration.GetRegistration().GetPatientByCpf(patientCpf);

        if (patient is null)
            return Menu.MenuOptions.ShowAgain;

        DateTime date = InputValidator.ValidateInput(
                "Insira a data da consulta [DDMMAAAA]: ",
                "Erro: data inserida inválida.",
                new BirthDateValidator()
                );

        TimeSpan startHour = InputValidator.ValidateInput(
                "Insira a hora de início da consulta [HHMM]: ",
                "Erro: a hora inserida é inválida.",
                new HourOfTheDayValidator()
                );

        TimeSpan endHour = InputValidator.ValidateInput(
                "Insira a hora de fim da consulta [HHMM]: ",
                "Erro: a hora inserida é inválida.",
                new HourOfTheDayValidator()
                );

        var startDate = date.Date.Add(startHour);
        var endDate = date.Date.Add(endHour);

        var interval = new TimeInterval(startDate, endDate);
        var consultation = new Consultation(patient, interval);

        return Menu.MenuOptions.DisplayAgendaMenu;
    }
}
