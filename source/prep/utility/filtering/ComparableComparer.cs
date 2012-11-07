using System;
using System.Collections.Generic;

namespace prep.utility.filtering
{
  public class ComparableComparer<TPropertyTypeToSortOn> : IComparer<TPropertyTypeToSortOn>
    where TPropertyTypeToSortOn : IComparable<TPropertyTypeToSortOn>
  {
    public int Compare(TPropertyTypeToSortOn x, TPropertyTypeToSortOn y)
    {
      return x.CompareTo(y);
    }
  }
}