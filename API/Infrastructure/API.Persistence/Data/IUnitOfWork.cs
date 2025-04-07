namespace API.Persistence.Data
{
    using Contracts;

    public interface IUnitOfWork:IAsyncDisposable
    {
        IJwtSettingsRepository JwtSettings { get; } //_uow.JwtSettings

        IUserRepository User { get; } //_uow.User

        IProductRepository Product { get; } //_uow.Product

        Task<bool> SaveAsync();
    }
}
