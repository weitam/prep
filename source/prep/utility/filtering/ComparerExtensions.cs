using System;
using System.Collections.Generic;

namespace prep.utility.filtering
{
  public static class ComparerExtensions
  {
    public static IComparer<TItemToSort> then_by<TItemToSort, TPropertyTypeToSortOn>(this IComparer<TItemToSort> comparer,PropertyAccessor<TItemToSort,TPropertyTypeToSortOn> accessor)
    {
      throw new NotImplementedException(); 
    }
  }
}