namespace prep.utility.filtering
{
  public class MatchCreationExtensionPoint<ItemToFilter, PropertyType>
  {
    public PropertyAccessor<ItemToFilter, PropertyType> accessor;
    public bool Nagating { get; set; }

    public MatchCreationExtensionPoint(PropertyAccessor<ItemToFilter, PropertyType> accessor)
    {
      this.accessor = accessor;
    }

    public MatchCreationExtensionPoint<ItemToFilter, PropertyType> not
    {
      get
      {
        Nagating = true;
        return this;
      }
    }
  }
}