using System.Collections.Generic;

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
      return new AnonymousCondition<ItemToFind>(x => new List<PropertyType>(values).Contains(accessor(x)));
    }

    public IMatchAn<ItemToFind> not_equal_to(PropertyType value)
    {
      return equal_to(value).not();
    }
  }
}