using System.Collections.Generic;

namespace prep.utility.filtering
{
    //public delegate

    public class Order<TTypeToSort>
    {
         public static IComparer<TTypeToSort> by_descending(PropertyAccessor<TTypeToSort, > property)
         {
             return new DescendingComparer<TTypeToSort>();
         }
    }




    public class DescendingComparer<TTypeToSort> : IComparer<TTypeToSort>
    {
        public int Compare(TTypeToSort x, TTypeToSort y)
        {
            return x
        }
    }
}