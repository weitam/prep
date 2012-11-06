using System;

namespace prep.utility.filtering
{
  public class ComparableMatchFactory<ItemToFind, PropertyType> where PropertyType : IComparable<PropertyType>
  {
    PropertyAccessor<ItemToFind, PropertyType> accessor;

    public ComparableMatchFactory(PropertyAccessor<ItemToFind, PropertyType> accessor)
    {
      this.accessor = accessor;
    }

    public IMatchAn<ItemToFind> greater_than(PropertyType value)
    {
      return new AnonymousCondition<ItemToFind>(x => accessor(x).CompareTo(value) > 0);
    }

    public IMatchAn<ItemToFind> between(PropertyType start, PropertyType end)
    {
      return
        new AnonymousCondition<ItemToFind>(x => accessor(x).CompareTo(start) >= 0 && accessor(x).CompareTo(end) <= 0);
    }
  }
}