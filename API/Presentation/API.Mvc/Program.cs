using API.Business.Service.Concrete;
using API.Business.Service.Contracts;
using API.Persistence.Configuration;
using API.Persistence.Data;
using API.Persistence.Validations.Concrete;
using API.Persistence.Validations.Contracts;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

#region Scoped
services.ConfigureScopedService<IUnitOfWork, UnitOfWork>();
services.ConfigureScopedService<IUserService, UserService>();
services.ConfigureScopedService<IJwtService, JwtService>();
services.ConfigureScopedService<ITokenService, TokenService>();
services.ConfigureScopedService<IProductService, ProductService>();
services.ConfigureScopedService<IValidatorService, ValidatorService>();
#endregion

#region Singleton
services.ConfigureSingletonService<IMessageProvider, MessageProvider>();
#endregion

// Configure services.
services.ConfigureDbContext(builder.Configuration.GetConnectionString("DefaultConnection"));
services.ConfigureIdentity();
services.ConfigureValidator();
services.ConfigureAutoMapper();
services.ConfigureJwtService(services.BuildServiceProvider().GetService<IJwtService>().GetJwtSettings());
services.Configure<RouteOptions>(opt =>
{
    opt.LowercaseUrls = true;
});


services.AddControllers();
services.AddEndpointsApiExplorer();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
services.AddOpenApi();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(opt =>
    {
        opt.Theme = ScalarTheme.DeepSpace;
        opt.DarkMode = true;
        opt.WithTitle("Jwt Auth API");
        opt.WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient);
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();