using System;
using prep.utility.ranges;

namespace prep.utility.filtering
{
  public static class MatchCreationExtensions
  {
    public static IMatchAn<ItemToFind> equal_to<ItemToFind, PropertyType>(
        this IProvideAccessToCreatingMatchers<ItemToFind, PropertyType> extension_point, PropertyType value_to_equal)
    {
      return equal_to_any(extension_point, value_to_equal);
    }

    public static IMatchAn<ItemToFind> equal_to_any<ItemToFind, PropertyType>(
        this IProvideAccessToCreatingMatchers<ItemToFind, PropertyType> extension_point, params PropertyType[] values)
    {
      return create_using(extension_point, new EqualToAny<PropertyType>(values));
    }

    public static IMatchAn<ItemToFind> create_using<ItemToFind, PropertyType>(
        this IProvideAccessToCreatingMatchers<ItemToFind, PropertyType> extension_point,
        IMatchAn<PropertyType> real_criteria)
    {
      return extension_point.create_match_using(real_criteria);
    }

    public static IMatchAn<ItemToFind> create_from<ItemToFind, PropertyType>(
        this IProvideAccessToCreatingMatchers<ItemToFind, PropertyType> extension_point, Condition<ItemToFind> condition)
    {
      return new AnonymousCondition<ItemToFind>(condition);
    }

    public static IMatchAn<ItemToFind> greater_than<ItemToFind, PropertyType>(
        this IProvideAccessToCreatingMatchers<ItemToFind, PropertyType> extension_point, PropertyType value)
        where PropertyType : IComparable<PropertyType>
    {
      return create_using(extension_point,
                          new FallsInRange<PropertyType>(new RangeWithNoUpperBound<PropertyType>(value)));
    }

    public static IMatchAn<ItemToFind> between<ItemToFind, PropertyType>(
        this IProvideAccessToCreatingMatchers<ItemToFind, PropertyType> extension_point, PropertyType start,
        PropertyType end) where PropertyType : IComparable<PropertyType>
    {
      return create_using(extension_point,
                          new FallsInRange<PropertyType>(new InclusiveRange<PropertyType>(start, end)));
    }
  }


}
