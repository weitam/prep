namespace prep.utility.filtering
{
  public interface IProvideAccessToCreatingMatchers<ItemToFilter, PropertyType>
  {
    IMatchAn<ItemToFilter> create_match_using(IMatchAn<PropertyType> real_criteria);
  }
}