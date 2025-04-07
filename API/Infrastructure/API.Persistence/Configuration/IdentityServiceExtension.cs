using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace API.Persistence.Configuration
{
    using EntityFramework.Contexts;
    using Model.Entities;

    public static partial class ServiceExtension
    {
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentity<User, Role>(opt =>
                {
                    opt.User.RequireUniqueEmail = true;
                    opt.SignIn.RequireConfirmedEmail = true;
                    opt.SignIn.RequireConfirmedPhoneNumber = false;
                    opt.Tokens.EmailConfirmationTokenProvider = TokenOptions.DefaultEmailProvider;
                    opt.Password.RequiredLength = 6;
                    opt.Password.RequireUppercase = true;
                    opt.Password.RequireLowercase = true;
                    opt.Password.RequireNonAlphanumeric = false;
                    opt.Lockout.MaxFailedAccessAttempts = 5;
                    opt.Lockout.AllowedForNewUsers = false;
                    opt.User.AllowedUserNameCharacters =
                        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";

                })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(opt =>
            {
                opt.Cookie.Name = "JwtAuth";
                opt.Cookie.HttpOnly = true;
                opt.ExpireTimeSpan = TimeSpan.FromDays(1);
                opt.SlidingExpiration = true;
                opt.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
            });
        }
    }
}
