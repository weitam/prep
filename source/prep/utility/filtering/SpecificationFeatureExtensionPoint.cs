namespace prep.utility.filtering
{
  public delegate IProvideAccessToCreatingMatchers<TItemToFilter, TPropertyType, TDSLResult>
    CreateMatchExtensionPointDecorator_Behaviour<TItemToFilter, TPropertyType, TDSLResult>(
    IProvideAccessToCreatingMatchers<TItemToFilter, TPropertyType, TDSLResult> original);

  public class MatchFeatureExtensionPoint<TItemToFilter, TPropertyType, TReturnType> :
    IProvideAccessToCreatingMatchers<TItemToFilter, TPropertyType, TReturnType>
  {
    CreateTheDSLReturnType_Behaviour<TItemToFilter, TPropertyType, TReturnType> dsl_return_type_factory;
    CreateMatchExtensionPointDecorator_Behaviour<TItemToFilter, TPropertyType, TReturnType> decorator_factory;

    public MatchFeatureExtensionPoint(
      CreateTheDSLReturnType_Behaviour<TItemToFilter, TPropertyType, TReturnType> dsl_return_type_factory,
      CreateMatchExtensionPointDecorator_Behaviour<TItemToFilter, TPropertyType, TReturnType> decorator_factory)
    {
      this.dsl_return_type_factory = dsl_return_type_factory;
      this.decorator_factory = decorator_factory;
    }

    public IProvideAccessToCreatingMatchers<TItemToFilter, TPropertyType, TReturnType> not
    {
      get { return decorator_factory(this); }
    }

    public TReturnType creating_dsl_result_using(IMatchAn<TPropertyType> real_criteria)
    {
      return dsl_return_type_factory(real_criteria);
    }
  }
}