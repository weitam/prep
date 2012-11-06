namespace prep.utility.filtering
{
  public class MatchCreationExtensionPoint<TItemToFilter, TPropertyType, TReturnType> :
    IProvideAccessToCreatingMatchers<TItemToFilter, TPropertyType, TReturnType> 
  {
    PropertyAccessor<TItemToFilter, TPropertyType> accessor;

    public MatchCreationExtensionPoint(PropertyAccessor<TItemToFilter, TPropertyType> accessor)
    {
      this.accessor = accessor;
    }

    public IProvideAccessToCreatingMatchers<TItemToFilter, TPropertyType, IMatchAn<TItemToFilter>> not
    {
      get { return new NegatingMatchCreationExtensionPoint(this); }
    }

    class NegatingMatchCreationExtensionPoint :
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

    public TReturnType creating_dsl_result_using(IMatchAn<TPropertyType> real_criteria)
    {
      return new PropertyMatch<TItemToFilter, TPropertyType>(accessor, real_criteria);
    }
  }
}