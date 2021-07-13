using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Transaction.Data.Data;
using Transaction.Domain.Interfaces;
using Transaction.Domain.Models;

namespace Transaction.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly TransactionDataContext _transactionDataContext;

        public GenericRepository(TransactionDataContext transactionDataContext)
        {
            _transactionDataContext = transactionDataContext;
        }
        public void Add(T entity)
        {
            _transactionDataContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _transactionDataContext.Set<T>().Remove(entity);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _transactionDataContext.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _transactionDataContext.Set<T>().ToListAsync();
        }

        public void Update(T entity)
        {
            // attach entity to be changed
            _transactionDataContext.Set<T>().Attach(entity);
            _transactionDataContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
