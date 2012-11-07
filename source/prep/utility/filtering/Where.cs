namespace prep.utility.filtering
{
  public class Where<TItemToFind>
  {
    public static MatchFeatureExtensionPoint<TItemToFind,TPropertyType,IMatchAn<TItemToFind>> has_a<TPropertyType>(
      PropertyAccessor<TItemToFind, TPropertyType> accessor)
    {
      return new MatchFeatureExtensionPoint<TItemToFind,TPropertyType,IMatchAn<TItemToFind>>(
        real_criteria => new PropertyMatch<TItemToFind,TPropertyType>(accessor, real_criteria),
        original => new NegatingMatchCreationExtensionPoint<TItemToFind, TPropertyType>(original));
    }
  }
}