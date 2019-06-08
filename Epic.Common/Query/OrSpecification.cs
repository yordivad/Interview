using System;
using System.Linq;
using System.Linq.Expressions;

namespace Epic.Common.Query
{
    public class OrSpecification<T> : Specification<T>
    {
        private readonly Specification<T> left;
        private readonly Specification<T> right;

        public OrSpecification(Specification<T> left, Specification<T> right)
        {
            this.left = left;
            this.right = right;
        }

        public override Expression<Func<T, bool>> Spec =>
            Expression.Lambda<Func<T, bool>>(Expression.OrElse(left.Spec, right.Spec),
                left.Spec.Parameters.Single());
    }
}