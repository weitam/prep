namespace prep.utility.filtering
{
  public delegate PropertyType PropertyAccessor<in Target, out PropertyType>(Target item);
}