using System;

namespace Epic.Common.Domain
{
    /// <summary>
    ///     The entity is a persistent object, that has a unique identity
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Entity<K> : IEquatable<Entity<K>>


    {
        /// <summary>
        ///     The identity
        /// </summary>
        public K Id { get; set; }

        public bool Equals(Entity<K> other)
        {
            if (ReferenceEquals(other, null)) return false;

            if (ReferenceEquals(other, this)) return true;

            return other.Id.Equals(Id);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Entity<K>);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public static bool operator ==(Entity<K> a, Entity<K> b)
        {
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null)) return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity<K> a, Entity<K> b)
        {
            return !(a == b);
        }
    }
}