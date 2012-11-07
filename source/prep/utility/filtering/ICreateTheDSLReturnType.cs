using System.Collections.Generic;

namespace prep.utility.filtering
{
  public delegate TDSLReturnType CreateTheDSLReturnType_Behaviour<TItemToFilter,TPropertyType, TDSLReturnType>(
    IMatchAn<TPropertyType> real_criteria);

  public interface ICreateTheDSLReturnType<TItemToFilter, TPropertyType, TReturnType>
  {
    TReturnType create_the_dsl_return_type(IMatchAn<TPropertyType> real_criteria);
  }

  public class SpecificationFactory<TItemToFilter, TPropertyType> :
    ICreateTheDSLReturnType<TItemToFilter, TPropertyType, IMatchAn<TItemToFilter>>
  {
    PropertyAccessor<TItemToFilter, TPropertyType> accessor;

    public SpecificationFactory(PropertyAccessor<TItemToFilter, TPropertyType> accessor)
    {
      this.accessor = accessor;
    }

    public IMatchAn<TItemToFilter> create_the_dsl_return_type(IMatchAn<TPropertyType> real_criteria)
    {
      return new PropertyMatch<TItemToFilter, TPropertyType>(accessor, real_criteria);
    }
  }

  public class FilteredEnumerableFactory<TItemToFilter, TPropertyType> :
    ICreateTheDSLReturnType<TItemToFilter, TPropertyType, IEnumerable<TItemToFilter>>
  {
    IEnumerable<TItemToFilter> items;
    IProvideAccessToCreatingMatchers<TItemToFilter, TPropertyType, IMatchAn<TItemToFilter>> match_creation_extension_point;

    public FilteredEnumerableFactory(IEnumerable<TItemToFilter> items,
                                     IProvideAccessToCreatingMatchers<TItemToFilter, TPropertyType, IMatchAn<TItemToFilter>>
                                       match_creation_extension_point)
    {
      this.items = items;
      this.match_creation_extension_point = match_creation_extension_point;
    }

    public IEnumerable<TItemToFilter> create_the_dsl_return_type(IMatchAn<TPropertyType> real_criteria)
    {
      return items.all_items_matching(match_creation_extension_point.create_using(real_criteria));
    }
  }
}