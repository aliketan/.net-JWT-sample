using Microsoft.EntityFrameworkCore;

namespace API.Persistence.Data.Concrete
{
    using Model.Entities;
    using Contracts;
    using Persistence.Repository.EntityFramework.Concrete;

    public class ProductRepository : EfRepositoryBase<Product>, IProductRepository
    {
        #region Constructor
        public ProductRepository(DbContext context) : base(context)
        {

        }
        #endregion
    }
}
