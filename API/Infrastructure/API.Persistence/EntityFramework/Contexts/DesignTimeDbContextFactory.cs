using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace API.Persistence.EntityFramework.Contexts
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../..", "Presentation/API.Mvc"))  // Set the base path to the current directory
                .AddJsonFile("appsettings.json")  // Read from appsettings.json
                .Build();

            builder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            return new ApplicationDbContext(builder.Options);
        }
    }
}