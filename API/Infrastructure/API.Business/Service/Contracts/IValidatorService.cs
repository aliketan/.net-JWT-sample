using FluentValidation;

namespace API.Business.Service.Contracts
{
    public interface IValidatorService
    {
        IValidator<T> GetValidator<T>() where T : class;
    }
}
