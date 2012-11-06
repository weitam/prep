namespace prep.utility.filtering
{
  public class Where<TItemToFind>
  {
    public static MatchCreationExtensionPoint<TItemToFind, TPropertyType> has_a<TPropertyType>(
      PropertyAccessor<TItemToFind, TPropertyType> accessor)
    {
      return new MatchCreationExtensionPoint<TItemToFind, TPropertyType>(accessor);
    }
  }
}