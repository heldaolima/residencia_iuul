﻿namespace DesafiosCSharp.Projeto_8;

public class CertidaoNascimento
{
  private DateTime DataEmissao { get; }
  public Pessoa _Pessoa { get; private set; }

  public CertidaoNascimento(DateTime data, Pessoa pessoa)
  {
    DataEmissao = data;
    _Pessoa = pessoa;
  }
}
