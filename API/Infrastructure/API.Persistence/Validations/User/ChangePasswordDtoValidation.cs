using FluentValidation;

namespace API.Persistence.Validations.User
{
    using Contracts;
    using Model.Dtos.User;
    using Utility.Constants.Pattern;

    public class ChangePasswordDtoValidation : AbstractValidator<ChangePasswordDto>
    {
        public ChangePasswordDtoValidation(IMessageProvider provider)
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage(x => provider.NotEmpty(nameof(x.Id)));

            RuleFor(x => x.CurrentPassword)
                .NotEmpty().WithMessage(x => provider.NotEmpty(nameof(x.CurrentPassword)));

            RuleFor(x => x.NewPassword)
                .NotEmpty().WithMessage(x => provider.NotEmpty(nameof(x.NewPassword)))
                .MinimumLength(6).WithMessage(x => provider.MinLength(nameof(x.NewPassword), 6))
                .MaximumLength(30).WithMessage(x => provider.MaxLength(nameof(x.NewPassword), 30))
                .Matches(RegexConsts.PasswordRegexPattern).WithMessage(_ => provider.WeekPassword());
        }
    }
}
