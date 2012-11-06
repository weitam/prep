using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using prep.utility;
using prep.utility.filtering;

namespace prep.specs
{
  [Subject(typeof(EnumerableExtensions))]
  public class EnumerableExtensionsSpecs
  {
    public abstract class concern : Observes
    {
    }

    public class when_filtering_a_set_of_items_by_a_condition : concern
    {
      Establish c = () =>
      {
        numbers = Enumerable.Range(1, 7);
      };

      Because b = () =>
        results = numbers.all_items_matching(new AnonymousCondition<int>(x => x%2 == 0));

      It should_only_return_the_items_that_meet_the_condition = () =>
        results.ShouldContain(2, 4, 6);

      static IEnumerable<int> results;
      static IEnumerable<int> numbers;
    }
  }
}