using System;

namespace prep.utility.filtering
{
  public class ComparableMatchFactory<ItemToFind, PropertyType> : ICreateMatchers<ItemToFind, PropertyType>
    where PropertyType : IComparable<PropertyType>
  {
    PropertyAccessor<ItemToFind, PropertyType> accessor;
    ICreateMatchers<ItemToFind, PropertyType> original;

    public ComparableMatchFactory(PropertyAccessor<ItemToFind, PropertyType> accessor, 
      ICreateMatchers<ItemToFind, PropertyType> original)
    {
      this.accessor = accessor;
      this.original = original;
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
      return original.equal_to(value_to_equal);
    }

    public IMatchAn<ItemToFind> equal_to_any(params PropertyType[] values)
    {
      return original.equal_to_any(values);
    }

    public IMatchAn<ItemToFind> not_equal_to(PropertyType value)
    {
      return original.not_equal_to(value);
    }
  }
}