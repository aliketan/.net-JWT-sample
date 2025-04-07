using FluentValidation;

namespace API.Persistence.Validations.User
{
    using Contracts;
    using Utility.Constants.Pattern;
    using Model.Dtos.User;

    public class RegisterDtoValidation : AbstractValidator<UserRegisterDto>
    {
        public RegisterDtoValidation(IMessageProvider provider)
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage(x => provider.NotEmpty(nameof(x.FirstName)))
                .MaximumLength(50).WithMessage(x => provider.MaxLength(nameof(x.FirstName), 50));

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage(x => provider.NotEmpty(nameof(x.LastName)))
                .MaximumLength(50).WithMessage(x => provider.MaxLength(nameof(x.LastName), 50));

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage(x => provider.NotEmpty(nameof(x.Email)))
                .EmailAddress().WithMessage(_ => provider.InvalidEmailAddress());

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage(x => provider.NotEmpty(nameof(x.Password)))
                .MinimumLength(6).WithMessage(x => provider.MinLength(nameof(x.Password), 6))
                .MaximumLength(30).WithMessage(x => provider.MaxLength(nameof(x.Password), 30))
                .Matches(RegexConsts.PasswordRegexPattern).WithMessage(_ => provider.WeekPassword());

            RuleFor(x => x.Roles)
                .Must(array => array == null || array.All(element => !string.IsNullOrWhiteSpace(element)))
                .WithMessage(x => provider.NotEmpty(nameof(x.Roles)));
        }
    }
}
