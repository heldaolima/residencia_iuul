namespace DesafiosCSharp.Projeto_8;

public class Pessoa
{
  public String Nome { get; }
  private CertidaoNascimento? certidao;
  public CertidaoNascimento? Certidao => certidao;

  public Pessoa(String nome)
  {
    this.Nome = nome;
  }

  public void SetCertidao(CertidaoNascimento certidao)
  {
    if (this.certidao is null)
    {
      this.certidao = certidao;
    }
  }
}
