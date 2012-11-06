using prep.utility.filtering;

namespace prep.collections
{
  public delegate ProductionStudio AMoviesProductionStudio(Movie movie);

  public class Where<ItemToFind>
  {
    public static AMoviesProductionStudio has_a(AMoviesProductionStudio accessor)
    {
      return accessor;
    }
  }

  public static class MovieExtensions
  {
    public static IMatchAn<Movie> equal_to(this AMoviesProductionStudio accessor,
                                           ProductionStudio value)
    {
      return new AnonymousCondition<Movie>(x => x.production_studio == value);
    }
  }
}