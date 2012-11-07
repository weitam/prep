namespace prep.utility.filtering
{
  public class NegatingMatchCreationExtensionPoint<TItemToFilter, TPropertyType> :
    IProvideAccessToCreatingMatchers<TItemToFilter, TPropertyType, IMatchAn<TItemToFilter>>
  {
    IProvideAccessToCreatingMatchers<TItemToFilter, TPropertyType, IMatchAn<TItemToFilter>> original;

    public NegatingMatchCreationExtensionPoint(
      IProvideAccessToCreatingMatchers<TItemToFilter, TPropertyType, IMatchAn<TItemToFilter>> original)
    {
      this.original = original;
    }

    public IMatchAn<TItemToFilter> creating_dsl_result_using(IMatchAn<TPropertyType> real_criteria)
    {
      return original.creating_dsl_result_using(real_criteria).not();
    }
  }
}