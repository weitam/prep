using System;
using System.Collections.Generic;

namespace prep.utility.filtering
{
  public class Order<TTypeToSort>
  {
    public static IComparer<TTypeToSort> by_descending<TPropertyTypeToSortOn>(PropertyAccessor<TTypeToSort,TPropertyTypeToSortOn> accessor) where TPropertyTypeToSortOn : IComparable<TPropertyTypeToSortOn>
    {
      return new DescendingComparer<TTypeToSort, TPropertyTypeToSortOn>(new CustomComparer<TTypeToSort, TPropertyTypeToSortOn>(accessor));
    }
    public static IComparer<TTypeToSort> by<TPropertyTypeToSortOn>(PropertyAccessor<TTypeToSort,TPropertyTypeToSortOn> accessor) where TPropertyTypeToSortOn : IComparable<TPropertyTypeToSortOn>
    {
      return new CustomComparer<TTypeToSort,TPropertyTypeToSortOn>(accessor);
    }
  }

  public class DescendingComparer<TTypeToSort, TPropertyTypeToSortOn> : IComparer<TTypeToSort> where TPropertyTypeToSortOn : IComparable<TPropertyTypeToSortOn>
    {
      CustomComparer<TTypeToSort, TPropertyTypeToSortOn> _customComparer;

      public DescendingComparer(CustomComparer<TTypeToSort, TPropertyTypeToSortOn> customComparer)
      {
          _customComparer = customComparer;
      }

      public int Compare(TTypeToSort x, TTypeToSort y)
      {
          return _customComparer.Compare(y, x);
      }
    }

    public class CustomComparer<TTypeToSort,TPropertyTypeToSortOn> : IComparer<TTypeToSort> where TPropertyTypeToSortOn : IComparable<TPropertyTypeToSortOn>
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