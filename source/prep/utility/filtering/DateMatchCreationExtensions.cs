using System;

namespace prep.utility.filtering
{
  public static class DateMatchCreationExtensions
  {
    public static TDSLReturnType between<TItemToFind,TDSLReturnType>(
      this IProvideAccessToCreatingMatchers<TItemToFind, DateTime,TDSLReturnType> extension_point, int start, int end)
    {
      return extension_point.creating_dsl_result_using(Where<DateTime>.has_a(x => x.Year).between(start, end));
    }
  }
}
