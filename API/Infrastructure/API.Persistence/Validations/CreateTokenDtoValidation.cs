using FluentValidation;

namespace API.Persistence.Validations
{
    using Model.Dtos;
    using Contracts;
    using API.Model.Dtos.Jwt;

    public class CreateTokenDtoValidation : AbstractValidator<CreateTokenDto>
    {
        public CreateTokenDtoValidation(IMessageProvider provider)
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage(x => provider.NotEmpty(nameof(x.Email)))
                .EmailAddress().WithMessage(_ => provider.InvalidEmailAddress());

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage(x => provider.NotEmpty(nameof(x.Password)));
        }
    }
}
