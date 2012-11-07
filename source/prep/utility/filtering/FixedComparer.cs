using System.Collections.Generic;

namespace prep.utility.filtering
{
  public class FixedComparer<TPropertyTypeToSortOn> : IComparer<TPropertyTypeToSortOn>
  {
    IList<TPropertyTypeToSortOn> values;

    public FixedComparer(params TPropertyTypeToSortOn[] values)
    {
      this.values = new List<TPropertyTypeToSortOn>(values);
    }

    public int Compare(TPropertyTypeToSortOn x, TPropertyTypeToSortOn y)
    {
      return values.IndexOf(x).CompareTo(values.IndexOf(y));
    }
  }
}