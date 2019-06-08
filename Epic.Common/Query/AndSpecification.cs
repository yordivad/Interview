using System;
using System.Linq;
using System.Linq.Expressions;

namespace Epic.Common.Query
{
    public class AndSpecification<T> : Specification<T>
    {
        private readonly Specification<T> left;
        private readonly Specification<T> right;

        public AndSpecification(Specification<T> left, Specification<T> rigth)
        {
            this.left = left;
            right = rigth;
        }

        public override Expression<Func<T, bool>> Spec =>
            Expression.Lambda<Func<T, bool>>(Expression.AndAlso(left.Spec, right.Spec),
                left.Spec.Parameters.Single());
    }
}