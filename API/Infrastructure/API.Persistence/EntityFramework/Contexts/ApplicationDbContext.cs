using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.Persistence.EntityFramework.Contexts
{
    using Model.Entities;

    public class ApplicationDbContext : IdentityDbContext<User, Role, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        public DbSet<Role> Role { get; set; }

        public DbSet<RoleClaim> RoleClaim { get; set; }

        public DbSet<User> User { get; set; }

        public DbSet<UserClaim> UserClaim { get; set; }

        public DbSet<UserLogin> UserLogin { get; set; }

        public DbSet<UserRole> UserRole { get; set; }

        public DbSet<UserToken> UserToken { get; set; }

        public DbSet<JwtSettings> JwtSettings { get; set; }

        public DbSet<Product> Product { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
            ChangeTracker.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}



