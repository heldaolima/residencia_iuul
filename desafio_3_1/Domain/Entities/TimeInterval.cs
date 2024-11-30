namespace DentalOffice.Domain.Entities;

public class TimeInterval : IEquatable<TimeInterval>
{
  public DateTime Start { get; private set; }
  public DateTime End { get; private set; }

  protected TimeInterval() { }

  public TimeInterval(DateTime start, DateTime end)
  {
    if (start > end)
    {
      throw new ArgumentException("A data inicial não pode ser maior que a data final.");
    }

    Start = start;
    End = end;
  }

  public TimeSpan Duration => End.Subtract(Start);

  public bool Overlaps(TimeInterval other)
  {
    return Start < other.End && other.Start < End;
  }

  public static bool operator ==(TimeInterval a, TimeInterval b)
  {
    if (a is null || b is null)
      return false;

    return a.Equals(b);
  }

  public static bool operator !=(TimeInterval a, TimeInterval b)
  {
    return !(a == b);
  }

  public override int GetHashCode()
  {
    return HashCode.Combine(Start, End);
  }

  public override bool Equals(object? obj)
  {
    if (obj is TimeInterval i)
    {
      return Equals(i);
    }

    return false;
  }

  public bool Equals(TimeInterval? other)
  {
    if (other is null)
      return false;

    if (ReferenceEquals(this, other))
      return true;

    return Start == other.Start && End == other.End;
  }
}
