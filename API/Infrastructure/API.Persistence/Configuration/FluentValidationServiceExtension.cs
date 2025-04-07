using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace API.Persistence.Configuration
{
    using Validations.User;

    public static partial class ServiceExtension
    {
        public static void ConfigureValidator(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<RegisterDtoValidation>();
        }
    }
}
