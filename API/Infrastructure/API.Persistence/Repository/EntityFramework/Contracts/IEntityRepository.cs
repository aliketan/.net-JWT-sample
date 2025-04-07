using System.Linq.Expressions;

namespace API.Persistence.Repository.EntityFramework.Contracts
{
    using Model.Contracts;

    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        void Detach(T entity);

        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate);
        Task<T> GetByIdAsync(int id);

        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task DeleteByIdAsync(int id);
        Task DeleteRangeAsync(IEnumerable<T> entities);
        Task<bool> ExistsAsync(int id);

        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate);
        T Get(Expression<Func<T, bool>> predicate);
        T GetById(int id);

        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Update(T entity);
        void Delete(T entity);
        void DeleteById(int id);
        void DeleteRange(IEnumerable<T> entities);
        bool Exists(int id);
    }
}
