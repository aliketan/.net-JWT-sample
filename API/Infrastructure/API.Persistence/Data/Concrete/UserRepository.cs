using Microsoft.EntityFrameworkCore;

namespace API.Persistence.Data.Concrete
{
    using Model.Entities;
    using Contracts;
    using Persistence.Repository.EntityFramework.Concrete;

    public class UserRepository : EfRepositoryBase<User>, IUserRepository
    {
        #region Constructor
        public UserRepository(DbContext context) : base(context)
        {

        }
        #endregion
    }
}
