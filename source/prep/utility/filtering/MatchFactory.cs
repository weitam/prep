namespace prep.utility.filtering
{
  public class MatchFactory<ItemToFind, PropertyType> : ICreateMatchers<ItemToFind, PropertyType>
  {
    PropertyAccessor<ItemToFind, PropertyType> accessor;

    public MatchFactory(PropertyAccessor<ItemToFind, PropertyType> accessor)
    {
      this.accessor = accessor;
    }

    public IMatchAn<ItemToFind> equal_to(PropertyType value_to_equal)
    {
      return equal_to_any(value_to_equal);
    }

    public IMatchAn<ItemToFind> equal_to_any(params PropertyType[] values)
    {
      return create_using(new EqualToAny<PropertyType>(values));
    }

    public IMatchAn<ItemToFind> not_equal_to(PropertyType value)
    {
      return equal_to(value).not();
    }

    public IMatchAn<ItemToFind> create_using(IMatchAn<PropertyType> real_criteria)
    {
      return new PropertyMatch<ItemToFind, PropertyType>(accessor,
                                                         real_criteria);
    }

    public IMatchAn<ItemToFind> create_from(Condition<ItemToFind> condition)
    {
      return new AnonymousCondition<ItemToFind>(condition);
    }
  }
}