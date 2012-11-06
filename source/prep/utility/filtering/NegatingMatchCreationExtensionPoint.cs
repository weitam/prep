namespace prep.utility.filtering
{
  public class NegatingMatchCreationExtensionPoint<ItemToFilter, PropertyType> : IProvideAccessToCreatingMatchers<ItemToFilter, PropertyType>
  {
    IProvideAccessToCreatingMatchers<ItemToFilter, PropertyType> original;

    public NegatingMatchCreationExtensionPoint(IProvideAccessToCreatingMatchers<ItemToFilter, PropertyType> original)
    {
      this.original = original;
    }

    public IMatchAn<ItemToFilter> create_match_using(IMatchAn<PropertyType> real_criteria)
    {
      return original.create_match_using(real_criteria).not();
    }
  }
}