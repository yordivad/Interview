namespace Epic.Common.Query
{
    public static class SpecificationExtension
    {
        public static Specification<T> And<T>(this Specification<T> left, Specification<T> right)
        {
            return new AndSpecification<T>(left, right);
        }

        public static Specification<T> Or<T>(this Specification<T> left, Specification<T> right)
        {
            return new OrSpecification<T>(left, right);
        }
    }
}