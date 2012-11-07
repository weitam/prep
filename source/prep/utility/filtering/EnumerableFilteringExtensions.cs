using System.Collections.Generic;

namespace prep.utility.filtering
{
  public static class EnumerableFilteringExtensions
  {
    public static MatchFeatureExtensionPoint<TItemToFilter, TPropertyType, IEnumerable<TItemToFilter>> where
      <TItemToFilter, TPropertyType>(
      this IEnumerable<TItemToFilter> items,
      PropertyAccessor
        <TItemToFilter, TPropertyType> accessor)
    {
      return new MatchFeatureExtensionPoint<TItemToFilter, TPropertyType, IEnumerable<TItemToFilter>>(
        new FilteredEnumerableFactory<TItemToFilter, TPropertyType>(items,
                                                                    Where<TItemToFilter>.has_a(accessor)).
          create_the_dsl_return_type,
        original => new NegatingEnumerableFilteringExtensionPoint<TItemToFilter, TPropertyType>(original));
    }
  }
}