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
      return new AnonymousCondition<ItemToFind>(x =>
                                                  {
                                                    var result = false;
                                                    foreach (var value in values)
                                                    {
                                                      result = result || accessor(x).Equals(value);
                                                    }
                                                    return result;
                                                  });

    }
  }
}