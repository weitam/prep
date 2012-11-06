using System.Collections.Generic;

namespace prep.utility.filtering
{
  public static class EnumerableFilteringExtensions
  {
    public static EnumerableFilteringExtensionPoint<TItemToFilter, TPropertyType> where<TItemToFilter, TPropertyType>(
      this IEnumerable<TItemToFilter> items,
      PropertyAccessor
        <TItemToFilter, TPropertyType> accessor)
    {
      return new EnumerableFilteringExtensionPoint<TItemToFilter, TPropertyType>(items,
                                                                               Where<TItemToFilter>.has_a(accessor));
    }
  }
}