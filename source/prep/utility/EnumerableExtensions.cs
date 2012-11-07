using System.Collections.Generic;
using prep.utility.filtering;

namespace prep.utility
{
  public static class EnumerableExtensions
  {
    public static IEnumerable<T> one_at_a_time<T>(this IEnumerable<T> items)
    {
      foreach (var item in items) yield return item;
    }

    static IEnumerable<Item> all_items_matching<Item>(this IEnumerable<Item> items, Condition<Item> condition)
    {
      foreach (var item in items)
        if (condition(item)) yield return item;
    }

    public static IEnumerable<Item> all_items_matching<Item>(this IEnumerable<Item> items, IMatchAn<Item> criteria)
    {
      return items.all_items_matching(criteria.matches);
    }

    public static IEnumerable<TItem> sort_using<TItem>(this IEnumerable<TItem> items,IComparer<TItem> comparer )
    {
      var list = new List<TItem>(items);
      list.Sort(comparer);
      return list;
    }
  }
}