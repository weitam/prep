namespace prep.utility.filtering
{
  public interface ICreateMatchers<in ItemToFind, in PropertyType>
  {
    IMatchAn<ItemToFind> equal_to(PropertyType value_to_equal);
    IMatchAn<ItemToFind> equal_to_any(params PropertyType[] values);
    IMatchAn<ItemToFind> not_equal_to(PropertyType value);
  }
}