namespace prep.utility.filtering
{
  public interface IProvideAccessToCreatingMatchers<ItemToFilter, PropertyType,DSLReturnType>
  {
    DSLReturnType creating_dsl_result_using(IMatchAn<PropertyType> real_criteria);
  }
}