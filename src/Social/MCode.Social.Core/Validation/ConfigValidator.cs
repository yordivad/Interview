using FluentValidation;
using MCode.Social.Core.Domain;

namespace MCode.Social.Core.Validation
{
    public class ConfigValidator: AbstractValidator<Config>
    {
        public ConfigValidator()
        {
            this.RuleFor(c => c.Server).NotEmpty().NotNull();
        }
    }
}