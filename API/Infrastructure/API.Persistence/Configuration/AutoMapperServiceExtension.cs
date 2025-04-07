using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace API.Persistence.Configuration
{
    public static partial class ServiceExtension
    {
        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
