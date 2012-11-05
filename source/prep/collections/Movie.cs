using System;

namespace prep.collections
{
  public class Movie : IEquatable<Movie>
  {
    string _title;

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

      return ReferenceEquals(this,other) || title == other.title;
    }

    public override bool Equals(object obj)
    {
      return Equals(obj as Movie);
    }

    public override int GetHashCode()
    {
      return this.title.GetHashCode();
    }
  }
}