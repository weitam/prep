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

  public class EnumerableFilteringExtensionPoint<TItemToFilter, TPropertyType> :
    IProvideAccessToCreatingMatchers<TItemToFilter, TPropertyType, IEnumerable<TItemToFilter>>
  {
    IEnumerable<TItemToFilter> original_set;
    IProvideAccessToCreatingMatchers<TItemToFilter, TPropertyType, IMatchAn<TItemToFilter>> match_creation_extension_point;

    public EnumerableFilteringExtensionPoint(IEnumerable<TItemToFilter> original_set,
                                             IProvideAccessToCreatingMatchers
                                               <TItemToFilter, TPropertyType, IMatchAn<TItemToFilter>>
                                               match_creation_extension_point)
    {
      this.original_set = original_set;
      this.match_creation_extension_point = match_creation_extension_point;
    }

    public IProvideAccessToCreatingMatchers<TItemToFilter, TPropertyType, IEnumerable<TItemToFilter>> not
    {
      get { return new NegatingEnumerableFilteringExtensionPoint(this); }
    }

    class NegatingEnumerableFilteringExtensionPoint :
      IProvideAccessToCreatingMatchers<TItemToFilter, TPropertyType, IEnumerable<TItemToFilter>>
    {
      IProvideAccessToCreatingMatchers<TItemToFilter, TPropertyType, IEnumerable<TItemToFilter>> original;

      public NegatingEnumerableFilteringExtensionPoint(
        IProvideAccessToCreatingMatchers<TItemToFilter, TPropertyType, IEnumerable<TItemToFilter>> original)
      {
        this.original = original;
      }

      public IEnumerable<TItemToFilter> creating_dsl_result_using(IMatchAn<TPropertyType> real_criteria)
      {
        return original.creating_dsl_result_using(real_criteria.not());
      }
    }

    public IEnumerable<TItemToFilter> creating_dsl_result_using(IMatchAn<TPropertyType> real_criteria)
    {
      return original_set.all_items_matching(match_creation_extension_point.creating_dsl_result_using(real_criteria));
    }
  }
}