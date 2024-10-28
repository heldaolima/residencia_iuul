using System.Globalization;

String? nome;
while (true)
{
  Console.Write("Insira o nome: ");
  nome = Console.ReadLine();
  if (nome is null || nome.Trim().Length < 5)
  {
    Console.WriteLine("Erro: o nome deve ter no mínimo 5 letras.");
    continue;
  }
  break;
}

nome = nome.Trim();

String? dataNascimentoStr;
DateTime dataNascimento = new DateTime();
while (true)
{
  Console.Write("Insira a data de nascimento [DD/MM/AAAA]: ");
  dataNascimentoStr = Console.ReadLine();
  if (dataNascimentoStr is null)
  {
    Console.WriteLine("Erro: a data deve ser no formato DD/MM/AAAA.");
    continue;
  }
  else
  {
    try
    {
      dataNascimento = DateTime.ParseExact(dataNascimentoStr.Trim(), "dd/MM/yyyy", new CultureInfo("pt-BR"));
    }
    catch (FormatException)
    {
      Console.WriteLine("Erro: a data deve ser no formato DD/MM/AAAA.");
      continue;
    }
  }

  break;
}

bool IsValidCpf(String cpf)
{
  if (cpf.Length != 11)
    return false;

  if (cpf.Distinct().Count() == 1)
    return false;

  if (!cpf.All((c) => char.IsDigit(c)))
    return false;

  int[] cpfNums = cpf.Select((c) => int.Parse(c.ToString())).ToArray();

  int primeiroVerificador = cpfNums[9];
  int segundoVerificador = cpfNums[10];

  int mult = 10;
  int soma = 0;
  for (int d = 0; d < 9; d++)
  {
    soma += mult * cpfNums[d];
    mult--;
  }

  int resto = soma % 11;
  if ((resto == 0 || resto == 1) && primeiroVerificador != 0)
    return false;
  else if (primeiroVerificador != 11 - resto)
    return false;


  mult = 11;
  soma = 0;
  for (int i = 0; i < 10; i++)
  {
    soma += cpfNums[i] * mult;
    mult--;
  }

  if ((resto == 0 || resto == 1) && segundoVerificador != 0)
    return false;
  else if (segundoVerificador != 11 - resto)
    return false;

  return true;
}

String? cpf;
while (true)
{
  Console.Write("Insira o CPF (apenas números): ");
  cpf = Console.ReadLine();
  if (cpf is null)
  {
    Console.WriteLine("Erro! CPF inválido!");
    continue;
  }

  cpf = cpf.Trim();
  if (IsValidCpf(cpf))
    break;
  else
  {
    Console.WriteLine("Erro! CPF inválido!");
    continue;
  }
}

String? rendaMensalStr;
float rendaMensal;
while (true)
{
  Console.Write("Insira a renda mensal: ");
  rendaMensalStr = Console.ReadLine();
  if (rendaMensalStr is null)
  {
    Console.WriteLine("Erro! Insira um número flutuante >= 0.");
    continue;
  }

  try
  {
    rendaMensal = float.Parse(rendaMensalStr.Trim(), new CultureInfo("pt-BR"));
    if (rendaMensal < 0)
    {
      Console.WriteLine("Erro! Insira um número flutuante >= 0.");
      continue;
    }
    break;
  }
  catch (Exception)
  {
    Console.WriteLine("Erro! Insira um número flutuante >= 0.");
    continue;
  }
}

String? estadoCivilStr;
char estadoCivil;
char[] estadoCivilOptions = ['C', 'S', 'V', 'D'];
while (true)
{
  Console.Write("Insira o Estado Civil [C, S, V, D]: ");
  estadoCivilStr = Console.ReadLine();
  if (estadoCivilStr is null)
  {
    Console.WriteLine("Erro! Tente novamente.");
    continue;
  }

  estadoCivil = estadoCivilStr.Trim()[0];
  estadoCivil = char.ToUpper(estadoCivil);
  if (!estadoCivilOptions.Contains(estadoCivil))
  {
    Console.WriteLine("Erro! Tente novamente.");
    continue;
  }
  break;
}

String? dependentesStr;
int dependentes;
while (true)
{
  Console.Write("Insira o número de dependentes (0 a 10): ");
  dependentesStr = Console.ReadLine();
  if (dependentesStr is null)
  {
    Console.WriteLine("Erro! Tente novamente.");
    continue;
  }

  try
  {
    dependentes = int.Parse(dependentesStr.Trim());
    if (dependentes < 0 || dependentes > 10)
    {
      Console.WriteLine("Erro! Valor inválido. Tente novamente");
      continue;
    }
    break;
  }
  catch (Exception)
  {
    Console.WriteLine("Erro! Formato inválido. Tente novamente.");
    continue;
  }
}

Console.WriteLine($"Nome: {nome}");
Console.WriteLine($"CPF: {cpf}");
Console.WriteLine($"Data de nascimento: {dataNascimento.ToString()}");
Console.WriteLine($"Renda Mensal: {rendaMensal: 0.00}");
Console.WriteLine($"Estado Civil: {estadoCivil}");
Console.WriteLine($"Número de dependentes: {dependentes}");

