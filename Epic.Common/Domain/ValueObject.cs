using System;

namespace Epic.Common.Domain
{
    /// <summary>
    ///     The class to identify an immutable object that don't have any identity
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ValueObject<T> : IEquatable<T>
        where T : ValueObject<T>
    {
        public bool Equals(T other)
        {
            if (ReferenceEquals(other, null))
                return false;
            return ReferenceEquals(this, other) || IsEqual(other);
        }

        /// <summary>
        ///     Compare two object to verify if they are equal
        /// </summary>
        /// <param name="other"></param>
        /// <returns>[True] if both are equal, [False] otherwise</returns>
        protected abstract bool IsEqual(T other);

        public override bool Equals(object obj)
        {
            return Equals(obj as T);
        }

        public abstract override int GetHashCode();

        public static bool operator ==(ValueObject<T> a, ValueObject<T> b)
        {
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null)) return false;

            return a.Equals(b);
        }

        public static bool operator !=(ValueObject<T> a, ValueObject<T> b)
        {
            return !(a == b);
        }
    }
}