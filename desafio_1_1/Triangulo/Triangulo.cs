﻿namespace DesafiosCSharp.Projeto_3;

using DesafiosCSharp.Projeto_2;

public class Triangulo
{
  public enum TipoTriangulo
  {
    Equilatero,
    Isosceles,
    Escaleno,
  }

  private Vertice a, b, c;
  private double d_ab, d_bc, d_ca;
  private double perimetro;
  private TipoTriangulo tipo;

  public Triangulo(Vertice a, Vertice b, Vertice c)
  {
    double d_ab = Math.Round(a.Distancia(b), 2);
    double d_bc = Math.Round(b.Distancia(c), 2);
    double d_ca = Math.Round(c.Distancia(a), 2);

    if (
        d_ab + d_bc > d_ca &&
        d_ab + d_ca > d_bc &&
        d_bc + d_ca > d_ab
        )
    {
      this.a = a;
      this.b = b;
      this.c = c;

      this.d_ab = d_ab;
      this.d_bc = d_bc;
      this.d_ca = d_ca;

      perimetro = d_ab + d_bc + d_ca;

      if (d_ab == d_bc && d_bc == d_ca)
        tipo = TipoTriangulo.Equilatero;
      else if (d_ab == d_bc || d_bc == d_ca || d_ca == d_ab)
        tipo = TipoTriangulo.Isosceles;
      else
        tipo = TipoTriangulo.Escaleno;
    }
    else
    {
      throw new ArgumentException("Os vértices dados não formam um triângulo.");
    }
  }

  private double CalcularArea()
  {
    double S = perimetro / 2;
    return Math.Sqrt(S * (S - d_ab) * (S - d_bc) * (S - d_ca));
  }

  public Vertice A => a;
  public Vertice B => b;
  public Vertice C => c;

  public TipoTriangulo Tipo => tipo;

  public double Perimetro => perimetro;
  public double Area => CalcularArea();

  public static bool operator ==(Triangulo a, Triangulo b)
  {
    if (ReferenceEquals(a, b))
      return true;

    if (a is null || b is null)
      return false;

    return a.Equals(b);
  }

  public static bool operator !=(Triangulo t1, Triangulo t2)
  {
    return !(t1 == t2);
  }

  public override int GetHashCode()
  {
    return HashCode.Combine(a, b, c);
  }

  public override bool Equals(object? obj)
  {
    if (obj is Triangulo t)
    {
      return Equals(t);
    }

    return false;
  }

  public bool Equals(Triangulo? other)
  {
    if (other is null) return false;

    return A == other.A && B == other.B && C == other.C;
  }
}
