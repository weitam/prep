namespace prep.utility.filtering
{
  public class PropertyMatch<ItemToMatch,PropertyType> : IMatchAn<ItemToMatch>
  {
    PropertyAccessor<ItemToMatch, PropertyType> accessor;
    IMatchAn<PropertyType> real_spec;

    public PropertyMatch(PropertyAccessor<ItemToMatch, PropertyType> accessor, IMatchAn<PropertyType> real_spec)
    {
      this.accessor = accessor;
      this.real_spec = real_spec;
    }

    public bool matches(ItemToMatch item)
    {
      var value = accessor(item);
      return real_spec.matches(value);
    }
  }
}