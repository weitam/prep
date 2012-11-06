namespace prep.utility.filtering
{
  public class Where<ItemToFind>
  {
    public static MatchCreationExtensionPoint<ItemToFind, PropertyType> has_a<PropertyType>(
      PropertyAccessor<ItemToFind, PropertyType> accessor)
    {
      return new MatchCreationExtensionPoint<ItemToFind, PropertyType>(accessor);
    }
  }
}