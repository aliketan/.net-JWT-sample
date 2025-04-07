namespace API.Persistence.Repository.EntityFramework.Contracts
{
    using Model.Contracts;

    public interface IEfRepository<T> where T:class, IEntity, new()
    {
        
    }
}
