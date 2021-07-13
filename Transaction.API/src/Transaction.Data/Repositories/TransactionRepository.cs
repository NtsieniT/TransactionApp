using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Transaction.Data.Data;
using Transaction.Domain.Interfaces;
using Transaction.Domain.Models;

namespace Transaction.Data.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly TransactionDataContext _context;

        public TransactionRepository(TransactionDataContext context)
        {
            _context = context;
        }

        public void Add(Transactions transaction)
        {
            _context.Transactions.Add(transaction);
        }

        public void Delete(int id)
        {
            var transaction = _context.Transactions.Find(id);
            if (transaction != null)
            {
                _context.Transactions.Remove(transaction);
            }
        }

        public async Task<Transactions> GetByIdAsync(int id)
        {
            return await _context.Transactions.Include(t => t.Type).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Transactions>> ListAllAsync()
        {
            return await _context.Transactions.Include(t => t.Type).ToListAsync();
        }

        public void Update(Transactions transaction)
        {
            _context.Entry(transaction).State = EntityState.Modified;
        }
    }
}
