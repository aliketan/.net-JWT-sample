using FluentValidation;

namespace API.Persistence.Validations.Product
{
    using Contracts;
    using Model.Dtos.Product;

    public class CreateProductDtoValidation : AbstractValidator<AddProductDto>
    {
        public CreateProductDtoValidation(IMessageProvider provider)
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(x => provider.NotEmpty(nameof(x.Name)));

            RuleFor(x => x.Price)
                .NotEmpty().WithMessage(x =>
                    provider.NotEmpty(nameof(x.Price)))
                .GreaterThan(0).WithMessage(x =>
                    provider.GreaterThan(nameof(x.Price), 0))
                .PrecisionScale(10, 2, true).WithMessage(x =>
                    provider.PrecisionScale(nameof(x.Price)));

            RuleFor(x => x.StockQuantity)
                .GreaterThanOrEqualTo(0).WithMessage(x => provider.GreaterThanOrEqualTo(nameof(x.StockQuantity), 0));

            RuleFor(x => x.IsActive)
                .NotEmpty().WithMessage(x => provider.GreaterThan(nameof(x.Price), 0));
        }
    }
}
