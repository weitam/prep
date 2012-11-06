using System;
using System.Collections.Generic;

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

    public IMatchAn<ItemToFind> equal_to(PropertyType value_to_equal)
    {
        return new MatchFactory<ItemToFind, PropertyType>(accessor).equal_to(value_to_equal);
    }

    public IMatchAn<ItemToFind> equal_to_any(params PropertyType[] values)
    {
        return new MatchFactory<ItemToFind, PropertyType>(accessor).equal_to_any(values);
    }

    public IMatchAn<ItemToFind> not_equal_to(PropertyType value)
    {
        return new MatchFactory<ItemToFind, PropertyType>(accessor).not_equal_to(value).not();
    }
    
  }
}