using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace API.Persistence.Repository.EntityFramework.Concrete
{
    using Model.Contracts;
    using Contracts;

    public abstract class EfRepositoryBase<T> : IEntityRepository<T> where T : class, IEntity, new()
    {
        private readonly DbContext _context;

        #region Constructor
        protected EfRepositoryBase(DbContext context)
        {
            _context = context;
            _context.ChangeTracker.AutoDetectChangesEnabled = false;
            _context.ChangeTracker.LazyLoadingEnabled = false;
        }
        #endregion

        public void Detach(T entity)
        {
            _context.Entry(entity).State = EntityState.Detached;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(predicate);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _context.Set<T>().AddRangeAsync(entities);
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await Task.CompletedTask;
        }

        public async Task DeleteByIdAsync(int id)
        {
            var data = await GetByIdAsync(id);
            if (data != null)
                _context.Set<T>().Remove(data);
            await Task.CompletedTask;
        }

        public async Task DeleteRangeAsync(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
            await Task.CompletedTask;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return (await _context.Set<T>().FindAsync(id)) != null;
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate).ToList();
        }

        public  T Get(Expression<Func<T, bool>> predicate)
        {
            return  _context.Set<T>().FirstOrDefault(predicate);
        }

        public  T GetById(int id)
        {
            return  _context.Set<T>().Find(id);
        }

        public void Add(T entity)
        {
             _context.Set<T>().Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
             _context.Set<T>().AddRange(entities);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void DeleteById(int id)
        {
            var data =  GetById(id);
            if (data != null)
                _context.Set<T>().Remove(data);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }

        public bool Exists(int id)
        {
            return _context.Set<T>().Find(id) != null;
        }
    }
}
