namespace DentalOffice.Validation.Validators;

public class CPFValidator : Validator<String>
{
  private const String invalidCpfError = "Erro: O CPF inserido está no formato inválido.";

  private bool IsVerifierValid(int verifier, int remainder)
  {
    if (remainder == 0 || remainder == 1)
      return verifier == 0;
    return verifier == 11 - remainder;
  }

  public String? Validate(String value)
  {
    if (
        value.Length != 11 ||
        value.Distinct().Count() == 1 ||
        !value.All((c) => char.IsDigit(c))
      )
      return invalidCpfError;

    int[] cpfNums = value.Select((c) => int.Parse(c.ToString())).ToArray();

    int firstVerifier = cpfNums[9];
    int secondVerifier = cpfNums[10];

    int mult = 10;
    int sum = 0;
    for (int d = 0; d < 9; d++)
    {
      sum += mult * cpfNums[d];
      mult--;
    }

    int remainder = sum % 11;
    if (!IsVerifierValid(firstVerifier, remainder))
      return invalidCpfError;

    mult = 11;
    sum = 0;
    for (int i = 0; i < 10; i++)
    {
      sum += cpfNums[i] * mult;
      mult--;
    }

    remainder = sum % 11;
    if (!IsVerifierValid(secondVerifier, remainder))
      return invalidCpfError;

    return null;
  }
}
