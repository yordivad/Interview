using System;
using System.Linq.Expressions;

namespace Epic.Common.Query
{
    /// <summary>
    ///     The specification class to create queries
    /// </summary>
    /// <typeparam name="T">the type of the entity</typeparam>
    public abstract class Specification<T>
    {
        private readonly Memoization<Func<T, bool>> predicate;

        public Specification()
        {
            predicate = new Memoization<Func<T, bool>>();
        }

        public abstract Expression<Func<T, bool>> Spec { get; }

        public bool IsSatifiedBy(T entity)
        {
            return predicate.Get(Spec.Compile).Invoke(entity);
        }
    }
}