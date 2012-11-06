using System;

namespace prep.utility.filtering
{
  public static class DateMatchCreationExtensions
  {
    public static IMatchAn<ItemToFind> between<ItemToFind>(
      this MatchCreationExtensionPoint<ItemToFind, DateTime> extension_point, int start, int end)
    {
      return extension_point.create_using(Where<DateTime>.has_a(x => x.Year).between(start, end));
    }
  }
}