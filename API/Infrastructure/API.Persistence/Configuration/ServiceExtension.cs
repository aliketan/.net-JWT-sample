using Microsoft.Extensions.DependencyInjection;

namespace API.Persistence.Configuration
{
    public static partial class ServiceExtension
    {
        public static void ConfigureScopedService<T, TEntity>(this IServiceCollection services) where T: class where TEntity: class, T
        {
            services.AddScoped<T, TEntity>();
        }

        public static void ConfigureSingletonService<T, TEntity>(this IServiceCollection services) where T : class where TEntity : class, T
        {
            services.AddSingleton<T, TEntity>();
        }

        public static void ConfigureTransientService<T, TEntity>(this IServiceCollection services) where T : class where TEntity : class, T
        {
            services.AddTransient<T, TEntity>();
        }
    }
}
