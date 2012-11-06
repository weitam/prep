namespace prep.utility.filtering
{
  public class AnonymousCondition<Item> : IMatchAn<Item>
  {
    Condition<Item> condition;

    public AnonymousCondition(Condition<Item> condition)
    {
      this.condition = condition;
    }

    public bool matches(Item item)
    {
      return condition(item);
    }
  }
}