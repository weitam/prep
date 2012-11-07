using System.Collections.Generic;

namespace prep.utility.filtering
{
  public class ReverseComparer<TTypeToSort> : IComparer<TTypeToSort>
  {
    IComparer<TTypeToSort> original_comparer;

    public ReverseComparer(IComparer<TTypeToSort> original_comparer)
    {
      this.original_comparer = original_comparer;
    }

    public int Compare(TTypeToSort x, TTypeToSort y)
    {
      return -original_comparer.Compare(x, y);
    }
  }
}