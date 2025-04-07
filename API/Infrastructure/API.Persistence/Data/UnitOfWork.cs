using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace API.Persistence.Data
{
    using EntityFramework.Contexts;
    using Contracts;
    using Concrete;

    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        private readonly IJwtSettingsRepository _jwtSettingsRepository;

        private readonly IUserRepository _userRepository;

        private readonly IProductRepository _productRepository;

        #region Constructor
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        #endregion

        public IJwtSettingsRepository JwtSettings => _jwtSettingsRepository ?? new JwtSettingsRepository(_context);

        public IUserRepository User => _userRepository ?? new UserRepository(_context);

        public IProductRepository Product => _productRepository ?? new ProductRepository(_context);

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        private static string HandleErrorMsg(Exception ex) => ex.InnerException != null ? ex.InnerException.Message : ex.Message;

        public async Task<bool> SaveAsync()
        {
            try
            {
                return (await _context.SaveChangesAsync()) > 0;
            }
            catch (ValidationException ex)
            {
                // Handle validation exceptions
                // Log the exception and provide a meaningful message
                throw new DbUpdateException($"Validation error: {HandleErrorMsg(ex)}");
            }
            catch (DbUpdateConcurrencyException ex)
            {
                // Handle concurrency exceptions
                // Log the exception and provide a meaningful message
                throw new DbUpdateException($"A concurrency error occurred: {HandleErrorMsg(ex)}");
            }
            catch (DbUpdateException ex)
            {
                // Handle database update exceptions
                // Log the exception and provide a meaningful message
                throw new DbUpdateException($"An error occurred while saving changes: {HandleErrorMsg(ex)}");
            }
            catch (Exception ex)
            {
                // Handle all other exceptions
                // Log the exception and provide a meaningful message
                throw new DbUpdateException($"An unexpected error occurred: {HandleErrorMsg(ex)}");
            }
        }
    }
}
