using prep.utility.filtering;

namespace prep.collections
{
  public delegate ProductionStudio AMoviesProductionStudio(Movie movie);

  public class Where<ItemToFind>
  {
    public Where()
    {
      
    }


    public static Where<Movie> has_a(AMoviesProductionStudio accessor)
    {
      return new Where<Movie>();
    }

    public IMatchAn<Movie> equal_to(ProductionStudio studio)
    {
      return new AnonymousCondition<Movie>(movie => movie.production_studio == studio); 
    }
  }
}