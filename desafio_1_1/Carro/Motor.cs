namespace DesafiosCSharp.Projeto_9;

public class Motor
{
  public double Cilindrada { get; }
  public Carro? CarroAssociado { get; private set; }

  public Motor(double cilindrada)
  {
    Cilindrada = cilindrada;
    CarroAssociado = null;
  }

  public void VerificarCarro(Carro carro)
  {
    if (CarroAssociado != null && CarroAssociado != carro)
    {
      throw new InvalidOperationException("O motor já está associado a um carro.");
    }
  }

  public void AssociarCarro(Carro carro)
  {
    VerificarCarro(carro);
    CarroAssociado = carro;
  }

  public void DesassociarCarro()
  {
    CarroAssociado = null;
  }
}
