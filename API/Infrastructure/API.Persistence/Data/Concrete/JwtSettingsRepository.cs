using Microsoft.EntityFrameworkCore;

namespace API.Persistence.Data.Concrete
{
    using Model.Entities;
    using Contracts;
    using Persistence.Repository.EntityFramework.Concrete;

    public class JwtSettingsRepository : EfRepositoryBase<JwtSettings>, IJwtSettingsRepository
    {
        #region Constructor
        public JwtSettingsRepository(DbContext context) : base(context)
        {

        }
        #endregion
    }
}
