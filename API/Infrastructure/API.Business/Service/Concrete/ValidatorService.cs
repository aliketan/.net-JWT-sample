using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace API.Business.Service.Concrete
{
    using Contracts;

    public class ValidatorService: IValidatorService
    {
        private readonly IServiceProvider _serviceProvider;

        #region Constructor
        public ValidatorService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        #endregion

        public IValidator<T> GetValidator<T>() where T : class => _serviceProvider.GetRequiredService<IValidator<T>>();
    }
}
