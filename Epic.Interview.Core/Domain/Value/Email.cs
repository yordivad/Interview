using Epic.Common.Domain;

namespace Epic.Interview.Core.Domain.Value
{
    public class Email : ValueObject<Email>
    {
        private readonly string email;

        public Email(string email)
        {
            this.email = email;
        }

        protected override bool IsEqual(Email other)
        {
            return email == other.email;
        }

        public override int GetHashCode()
        {
            return email.GetHashCode();
        }
    }
}