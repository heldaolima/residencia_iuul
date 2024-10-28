namespace CertidaoNascimento.Tests;
using DesafiosCSharp.Projeto_8;

public class UnitTest1
{
    [Fact]
    public void TestRelations()
    {
        Pessoa pessoa = new Pessoa("Hélder");
        CertidaoNascimento certidao = new CertidaoNascimento(new DateTime(), pessoa);

        Assert.Null(pessoa.Certidao);

        pessoa.SetCertidao(certidao);
        Assert.Equal(certidao, pessoa.Certidao);
    }
}
