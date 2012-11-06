namespace prep.utility.filtering
{
  public interface ICreateMatchers<ItemToFind, PropertyType>
  {
    IMatchAn<ItemToFind> equal_to(PropertyType value_to_equal);
    IMatchAn<ItemToFind> equal_to_any(params PropertyType[] values);
    IMatchAn<ItemToFind> not_equal_to(PropertyType value);
    IMatchAn<ItemToFind> create_from(Condition<ItemToFind> condition);
    IMatchAn<ItemToFind> create_using(IMatchAn<PropertyType> real_criteria);
  }
}