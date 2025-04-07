namespace API.Persistence.Data.Contracts
{
    using Model.Entities;
    using Persistence.Repository.EntityFramework.Contracts;

    public interface IProductRepository : IEntityRepository<Product>
    {
    }
}
