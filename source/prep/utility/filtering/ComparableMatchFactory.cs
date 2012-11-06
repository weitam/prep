using System;
using prep.utility.ranges;

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
      return create_using(new FallsInRange<PropertyType>(new RangeWithNoUpperBound<PropertyType>(value)));
    }

    public IMatchAn<ItemToFind> between(PropertyType start, PropertyType end)
    {
      return create_using(new FallsInRange<PropertyType>(new InclusiveRange<PropertyType>(start, end)));
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

    public IMatchAn<ItemToFind> create_from(Condition<ItemToFind> condition)
    {
      return original.create_from(condition);
    }

    public IMatchAn<ItemToFind> create_using(IMatchAn<PropertyType> real_criteria)
    {
      return original.create_using(real_criteria);
    }
  }
}