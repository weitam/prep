using System;
using prep.utility.ranges;

namespace prep.utility.filtering
{
  public static class MatchCreationExtensions
  {
    public static TDSLReturnType equal_to<TItemToFind, TPropertyType,TDSLReturnType>(
        this IProvideAccessToCreatingMatchers<TItemToFind, TPropertyType,TDSLReturnType> extension_point, TPropertyType value_to_equal)
    {
      return equal_to_any(extension_point, value_to_equal);
    }

    public static TDSLReturnType equal_to_any<TItemToFind, TPropertyType,TDSLReturnType>(
        this IProvideAccessToCreatingMatchers<TItemToFind, TPropertyType,TDSLReturnType> extension_point, params TPropertyType[] values)
    {
      return create_using(extension_point, new EqualToAny<TPropertyType>(values));
    }

    public static TDSLReturnType create_using<TItemToFind, TPropertyType,TDSLReturnType>(
        this IProvideAccessToCreatingMatchers<TItemToFind, TPropertyType,TDSLReturnType> extension_point,
        IMatchAn<TPropertyType> real_criteria)
    {
      return extension_point.creating_dsl_result_using(real_criteria);
    }

    public static TDSLReturnType greater_than<TItemToFind, TPropertyType,TDSLReturnType>(
        this IProvideAccessToCreatingMatchers<TItemToFind, TPropertyType,TDSLReturnType> extension_point, TPropertyType value)
        where TPropertyType : IComparable<TPropertyType>
    {
      return create_using(extension_point,
                          new FallsInRange<TPropertyType>(new RangeWithNoUpperBound<TPropertyType>(value)));
    }

    public static TDSLReturnType between<TItemToFind, TPropertyType,TDSLReturnType>(
        this IProvideAccessToCreatingMatchers<TItemToFind, TPropertyType,TDSLReturnType> extension_point, TPropertyType start,
        TPropertyType end) where TPropertyType : IComparable<TPropertyType>
    {
      return create_using(extension_point,
                          new FallsInRange<TPropertyType>(new InclusiveRange<TPropertyType>(start, end)));
    }
  }


}
