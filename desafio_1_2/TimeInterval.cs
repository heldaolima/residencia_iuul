namespace DentalOffice;

public class TimeInterval : IEquatable<TimeInterval>
{
  private DateTime start, end;
  public TimeInterval(DateTime start, DateTime end)
  {
    if (start > end)
    {
      throw new ArgumentException("A data inicial não pode ser maior que a data final.");
    }

    this.start = start;
    this.end = end;
  }

  public TimeSpan Duration => end.Subtract(start);
  public DateTime Start => start;
  public DateTime End => end;

  public bool Overlaps(TimeInterval other)
  {
    return start < other.End && other.Start < end;
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
    return HashCode.Combine(start, end);
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

    return start == other.Start && end == other.End;
  }
}
