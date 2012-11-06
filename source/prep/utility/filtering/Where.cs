namespace prep.utility.filtering
{
  public class Where<ItemToFind>
  {
    public static SpecificationFeatureExtensionPoint<ItemToFind, PropertyType> has_a<PropertyType>(
      PropertyAccessor<ItemToFind, PropertyType> accessor)
    {
      return new SpecificationFeatureExtensionPoint<ItemToFind, PropertyType>(accessor);
    }
  }
}