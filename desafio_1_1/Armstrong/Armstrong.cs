namespace DesafiosCSharp.Projeto_7;

public static class Armstrong
{
  private static int Power(int x, long y)
  {
    if (y == 0)
    {
      return 1;
    }

    if (y % 2 == 0)
    {
      return Power(x, y / 2) * Power(x, y / 2);
    }

    return x * Power(x, y / 2) * Power(x, y / 2);
  }

  private static uint Order(int x)
  {
    uint n = 0;
    while (x != 0)
    {
      n++;
      x /= 10;
    }
    return n;
  }

  public static bool IsArmstrong(this int x)
  {
    uint n = Order(x);

    int temp = x;
    int sum = 0;

    while (temp != 0)
    {
      int r = temp % 10;
      sum += Power(r, n);
      temp /= 10;
    }

    return (sum == x);
  }
}
