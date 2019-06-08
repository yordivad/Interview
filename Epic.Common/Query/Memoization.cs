using System;

namespace Epic.Common.Query
{
    public class Memoization<T>
    {
        private T value;

        public T Get(Func<T> apply)
        {
            if (value == null) value = apply();

            return value;
        }
    }
}