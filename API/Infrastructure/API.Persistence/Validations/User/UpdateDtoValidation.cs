using FluentValidation;

namespace API.Persistence.Validations.User
{
    using Contracts;
    using Model.Dtos.User;

    public class UpdateDtoValidation : AbstractValidator<UserUpdateDto>
    {
        public UpdateDtoValidation(IMessageProvider provider)
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage(x => provider.NotEmpty(nameof(x.Id)));
        }
    }
}
