using System.Collections.Generic;

namespace prep.utility.filtering
{
  public class PropertyComparer<TTypeToSortOn, TPropertyType> : IComparer<TTypeToSortOn>
  {
    PropertyAccessor<TTypeToSortOn, TPropertyType> accessor;
    IComparer<TPropertyType> real_comparer;

    public PropertyComparer(PropertyAccessor<TTypeToSortOn, TPropertyType> accessor,
                            IComparer<TPropertyType> real_comparer)
    {
      this.accessor = accessor;
      this.real_comparer = real_comparer;
    }

    public int Compare(TTypeToSortOn x, TTypeToSortOn y)
    {
      return real_comparer.Compare(accessor(x), accessor(y));
    }
  }
}