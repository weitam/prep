using System.Collections.Generic;

namespace prep.utility.filtering
{
  public class NegatingEnumerableFilteringExtensionPoint<TItemToFilter, TPropertyType> :
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
}