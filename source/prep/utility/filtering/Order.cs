using System;
using System.Collections.Generic;

namespace prep.utility.filtering
{
  public class Order<TTypeToSort>
  {
    public static IComparer<TTypeToSort> by<TPropertyTypeToSortOn>(
      PropertyAccessor<TTypeToSort, TPropertyTypeToSortOn> accessor,
      params TPropertyTypeToSortOn[] fixed_order)
    {
      
    }
    public static IComparer<TTypeToSort> by_descending<TPropertyTypeToSortOn>(
      PropertyAccessor<TTypeToSort, TPropertyTypeToSortOn> accessor)
      where TPropertyTypeToSortOn : IComparable<TPropertyTypeToSortOn>
    {
      return new ReverseComparer<TTypeToSort>(by(accessor));
    }

    public static IComparer<TTypeToSort> by<TPropertyTypeToSortOn>(
      PropertyAccessor<TTypeToSort, TPropertyTypeToSortOn> accessor)
      where TPropertyTypeToSortOn : IComparable<TPropertyTypeToSortOn>
    {
      return new CustomComparer<TTypeToSort, TPropertyTypeToSortOn>(accessor);
    }
  }

  public class CustomComparer<TTypeToSort, TPropertyTypeToSortOn> : IComparer<TTypeToSort>
    where TPropertyTypeToSortOn : IComparable<TPropertyTypeToSortOn>
  {
    PropertyAccessor<TTypeToSort, TPropertyTypeToSortOn> accessor;

    public CustomComparer(PropertyAccessor<TTypeToSort, TPropertyTypeToSortOn> accessor)
    {
      this.accessor = accessor;
    }

    public int Compare(TTypeToSort x, TTypeToSort y)
    {
      return accessor(x).CompareTo(accessor(y));
    }
  }
}