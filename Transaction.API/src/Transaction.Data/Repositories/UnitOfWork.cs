using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Transaction.Data.Data;
using Transaction.Domain.Interfaces;

namespace Transaction.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TransactionDataContext _transactionDataContext;

        public UnitOfWork(TransactionDataContext transactionDataContext)
        {
            _transactionDataContext = transactionDataContext;
        }

        public ITransactionRepository TransactionRepository => new TransactionRepository(_transactionDataContext);
        public ITypeRepository TypeRepository => new TypeRepository(_transactionDataContext);


        public async Task<bool> Complete()
        {
            return await _transactionDataContext.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            _transactionDataContext.Dispose();
        }
    }
}
