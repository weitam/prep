using System;

namespace prep.collections
{
  public class Movie : IEquatable<Movie>
  {
    private string _title;
    public string title
    {
      get { return _title ?? String.Empty; }
      set { _title = value; }
    }

    public ProductionStudio production_studio { get; set; }
    public Genre genre { get; set; }
    public int rating { get; set; }
    public DateTime date_published { get; set; }
    public bool Equals(Movie other)
    {
      if (other == null) return false;
      return title == other.title;
    }
  }
}