using CV_Manager.Core.Contracts;
using CV_Manager.DAL.Data;
using Microsoft.EntityFrameworkCore.Storage;

namespace CV_Manager.BLL.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        #region  fields
        private readonly AppDbContext _context;
        private IDbContextTransaction _transaction;
        #endregion

        #region ctor
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }
        #endregion

        #region methods
        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
            await _transaction.CommitAsync();
        }

        public async Task RollbackAsync()
        {
            await _transaction.RollbackAsync();
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
        #endregion
    }
}
