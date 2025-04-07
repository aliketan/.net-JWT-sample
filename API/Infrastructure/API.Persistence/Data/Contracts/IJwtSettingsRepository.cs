namespace API.Persistence.Data.Contracts
{
    using Model.Entities;
    using Persistence.Repository.EntityFramework.Contracts;

    public interface IJwtSettingsRepository : IEntityRepository<JwtSettings>
    {
    }
}
