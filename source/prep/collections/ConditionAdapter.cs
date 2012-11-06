using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using prep.utility.filtering;

namespace prep.collections
{
    public class ConditionAdapter: IMatchAn<Movie>
    {
        private Condition<Movie> _condition; 

        public ConditionAdapter(Condition<Movie> movieCondition)
        {
            _condition = movieCondition;
        }

        public bool matches(Movie item)
        {
            return _condition.Invoke(item);
        }
    }
}
