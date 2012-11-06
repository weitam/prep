namespace prep.utility.filtering
{
  public interface IMatchAn<in Item>
  {
    bool matches(Item item);
  }
}