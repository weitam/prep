using System;

namespace prep.utility.ranges
{
  public interface IContainValues<T> where T : IComparable<T>
  {
    bool contains(T value);
  }

  public class InclusiveRange<T> : IContainValues<T> where T : IComparable<T>
  {
    T start;
    T end;

    public InclusiveRange(T start, T end)
    {
      this.start = start;
      this.end = end;
    }

    public bool contains(T value)
    {
      return value.CompareTo(start) >= 0 && value.CompareTo(end) <= 0;
    }
  }

  public class RangeWithNoUpperBound<T> : IContainValues<T> where T : IComparable<T>
  {
    T start;

    public RangeWithNoUpperBound(T start)
    {
      this.start = start;
    }

    public bool contains(T value)
    {
      return value.CompareTo(start) > 0;
    }
  }

  public class DateYearRange<DateTime> : IContainValues<DateTime>
  {
      readonly int _start;
      readonly int _end;
      
      public DateYearRange(int start, int end)
      {
          _start = start;
          _end = end;
      }

      public bool contains(T value)
      {
          return value.Year
      }
  }
}