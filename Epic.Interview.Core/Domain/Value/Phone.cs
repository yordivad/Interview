using Epic.Common.Domain;

namespace Epic.Interview.Core.Domain.Value
{
    public class Phone : ValueObject<Phone>
    {
        public string Number { get; set; }

        protected override bool IsEqual(Phone other)
        {
            return this.Number.Equals(other.Number);
        }

        public override int GetHashCode()
        {
            return this.Number.GetHashCode();
        }
    }
}