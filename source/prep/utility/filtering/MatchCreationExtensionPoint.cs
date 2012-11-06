namespace prep.utility.filtering
{
  public class MatchCreationExtensionPoint<ItemToFilter, PropertyType>
  {
    public PropertyAccessor<ItemToFilter, PropertyType> accessor;

    public MatchCreationExtensionPoint(PropertyAccessor<ItemToFilter, PropertyType> accessor)
    {
      this.accessor = accessor;
    }
  }
}