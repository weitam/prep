namespace prep.utility.filtering
{
  public class MatchCreationExtensionPoint<ItemToFilter, PropertyType> : IProvideAccessToCreatingMatchers<ItemToFilter, PropertyType>
  {
    PropertyAccessor<ItemToFilter, PropertyType> accessor;

    public MatchCreationExtensionPoint(PropertyAccessor<ItemToFilter, PropertyType> accessor)
    {
      this.accessor = accessor;
    }

    public IProvideAccessToCreatingMatchers<ItemToFilter, PropertyType> not
    {
      get
      {
        return new NegatingMatchCreationExtensionPoint<ItemToFilter, PropertyType>(this);
      }
    }

    public IMatchAn<ItemToFilter> create_match_using(IMatchAn<PropertyType> real_criteria)
    {
      return new PropertyMatch<ItemToFilter, PropertyType>(accessor, real_criteria);
    }
  }
}