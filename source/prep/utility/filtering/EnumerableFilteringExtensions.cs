using System.Collections;
using System.Collections.Generic;

namespace prep.utility.filtering
{
  public static class EnumerableFilteringExtensions
  {
    public static FilteringEnumerable<ItemToFilter, PropertyType> where<ItemToFilter, PropertyType>(
      this IEnumerable<ItemToFilter> items,
      PropertyAccessor
        <ItemToFilter, PropertyType> accessor)
    {
      return new FilteringEnumerable<ItemToFilter, PropertyType>(items, accessor);
    }
  }

  public class FilteringEnumerable<ItemToFilter, PropertyType> : IEnumerable<ItemToFilter>
  {
    IEnumerable<ItemToFilter> original_set;
    PropertyAccessor<ItemToFilter, PropertyType> accessor;

    public FilteringEnumerable(IEnumerable<ItemToFilter> original_set,
                               PropertyAccessor<ItemToFilter, PropertyType> accessor)
    {
      this.original_set = original_set;
      this.accessor = accessor;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }

    public IEnumerator<ItemToFilter> GetEnumerator()
    {
      return original_set.GetEnumerator();
    }

    public IEnumerable<ItemToFilter> equal_to_any(params PropertyType[] values)
    {
      return original_set.all_items_matching(Where<ItemToFilter>.has_a(accessor).equal_to_any(values));
    }
  }
}