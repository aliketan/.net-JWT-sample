using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace API.Persistence.Configuration
{
    using EntityFramework.Contexts;

    public static partial class ServiceExtension
    {
        public static void ConfigureDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(option =>
            {
                option.UseSqlServer(connectionString, opt => opt.EnableRetryOnFailure());
            });
        }
    }
}
