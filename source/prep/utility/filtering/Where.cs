using System.Collections.Generic;
using System.Text.RegularExpressions;
using prep.collections;

namespace prep.utility.filtering
{
  public class Where<ItemToFind>
  {
    public static MatchFactory<ItemToFind, PropertyType> has_a<PropertyType>(
      PropertyAccessor<ItemToFind, PropertyType> accessor)
    {
      return new MatchFactory<ItemToFind, PropertyType>(accessor);
    }
  }

  public class MatchFactory<ItemToFind, PropertyType>
  {
    PropertyAccessor<ItemToFind, PropertyType> accessor;

    public MatchFactory(PropertyAccessor<ItemToFind, PropertyType> accessor)
    {
      this.accessor = accessor;
    }

    public IMatchAn<ItemToFind> equal_to(PropertyType value_to_equal)
    {
      return new AnonymousCondition<ItemToFind>(x => accessor(x).Equals(value_to_equal));
    }

    public IMatchAn<ItemToFind> equal_to_any(params PropertyType[] values)
    {
      return new AnonymousCondition<ItemToFind>(x => new List<PropertyType>(values).Contains(accessor(x)));
    }

    public IMatchAn<ItemToFind> not_equal_to(PropertyType value)
    {
      //  return !equal_to(value);
      return new AnonymousCondition<ItemToFind>(x => { return !equal_to(value).matches(x); });
      //return new AnonymousCondition<ItemToFind>(x => !accessor(x).Equals(value));
    }
  }
}