namespace DentalOffice.Presentation.ActionMenus;

using DentalOffice.Validation;
using DentalOffice.Validation.Parsers;
using DentalOffice.Validation.Validators;

public class ChooseListConsultationsMenu : Menu
{
    public MenuOptions Display()
    {
        char option = InputValidator.ValidateInput(
                "Apresentar a agenda T-Toda ou P-Período: ",
                new CharParser(),
                new CharAgendaValidator()
                );

        if (option == 'T')
            return MenuOptions.DisplayListAllConsultations;
        return MenuOptions.DisplayListConsultationsInsidePeriod;
    }
}
