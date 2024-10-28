using System.Globalization;

T ReadFromUser<T>(String msg, String errorMsg, Func<String, (T, bool)> parse)
{
  while (true)
  {
    Console.Write(msg);
    String? fromUser = Console.ReadLine();
    if (fromUser is null)
      continue;

    fromUser = fromUser.Trim();

    var (value, isValid) = parse(fromUser);
    if (isValid)
      return value;
    else
      Console.WriteLine(errorMsg);
  }
}

Func<String, (String, bool)> ParseName = (value) =>
{
  if (value.Length < 5)
  {
    return ("", false);
  }
  return (value, true);
};

String nome = ReadFromUser<String>(
    "Insira o nome: ",
    "Erro: O nome deve ter no mínimo 5 letras.",
    ParseName
  );

Func<String, (String, bool)> ParseCPF = (value) =>
{
  bool IsVerifierValid(int verifier, int remainder)
  {
    if (remainder == 0 || remainder == 1)
      return verifier == 0;
    return verifier == 11 - remainder;
  }

  if (
      value.Length != 11 ||
      value.Distinct().Count() == 1 ||
      !value.All((c) => char.IsDigit(c))
    )
    return (value, false);

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
    return (value, false);

  mult = 11;
  sum = 0;
  for (int i = 0; i < 10; i++)
  {
    sum += cpfNums[i] * mult;
    mult--;
  }

  remainder = sum % 11;
  if (!IsVerifierValid(secondVerifier, remainder))
    return (value, false);

  return (value, true);
};


String cpf = ReadFromUser<String>(
    "Insira o CPF (apenas números): ",
    "Erro: CPF inválido",
    ParseCPF
    );

Func<String, (DateTime, bool)> ParseBirthDate = (value) =>
{
  try
  {
    DateTime dataNascimento =
      DateTime.ParseExact(value, "dd/MM/yyyy", new CultureInfo("pt-BR"));
    return (dataNascimento, true);
  }
  catch (FormatException)
  {
    return (new DateTime(), false);
  }
};

DateTime dataNascimento = ReadFromUser<DateTime>(
    "Insira a data de nascimento [DD/MM/AAAA]: ",
    "Erro: a data de nascimento deve ser no formato [DD/MM/AAAA]",
    ParseBirthDate
  );


Func<String, (float, bool)> ParseIncome = (value) =>
{
  try
  {
    float income = float.Parse(value, new CultureInfo("pt-BR"));
    if (income < 0)
    {
      return (income, false);
    }

    return (income, true);
  }
  catch (Exception)
  {
    return (-1, false);
  }
};

float rendaMensal = ReadFromUser<float>(
    "Insira a renda mensal: ",
    "Erro: Insira um número flutuante >= 0.",
    ParseIncome
    );


Func<String, (char, bool)> ParseMaritalStatus = (value) =>
{
  if (value.Length == 0)
  {
    return ('c', false);
  }

  char[] options = ['C', 'S', 'V', 'D'];
  char maritalStatus = char.ToUpper(value[0]);
  if (options.Contains(maritalStatus))
  {
    return (maritalStatus, true);
  }

  return (maritalStatus, false);
};

char estadoCivil = ReadFromUser<char>(
    "Insira o Estado Civil [C, S, V, D]: ",
    "Erro: resposta inválida.",
    ParseMaritalStatus
    );


Func<String, (int, bool)> ParseDependents = (value) =>
{
  try
  {
    int dependents = int.Parse(value);
    if (dependents < 0 || dependents > 10)
      return (dependents, false);
    return (dependents, true);
  }
  catch (Exception)
  {
    return (0, false);
  }
};

int dependentes = ReadFromUser<int>(
    "Insira o número de dependentes (0 a 10): ",
    "Erro: entrada inválida.",
    ParseDependents
    );

Console.WriteLine("------------------------");
Console.WriteLine($"Nome: {nome}");
Console.WriteLine($"CPF: {cpf}");
Console.WriteLine($"Data de nascimento: {dataNascimento.ToString()}");
Console.WriteLine($"Renda Mensal: R${rendaMensal:0.00}");
Console.WriteLine($"Estado Civil: {estadoCivil}");
Console.WriteLine($"Número de dependentes: {dependentes}");

