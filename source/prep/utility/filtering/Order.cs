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
      return new PropertyComparer<TTypeToSort, TPropertyTypeToSortOn>(accessor,
                                                                      new FixedComparer<TPropertyTypeToSortOn>(
                                                                        fixed_order));
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
      return new PropertyComparer<TTypeToSort, TPropertyTypeToSortOn>(accessor,
                                                                      new ComparableComparer<TPropertyTypeToSortOn>());
    }
  }
}