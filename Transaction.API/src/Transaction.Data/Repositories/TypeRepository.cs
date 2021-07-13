using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Transaction.Data.Data;
using Transaction.Domain.Interfaces;
using Transaction.Domain.Models.Lookups;

namespace Transaction.Data.Repositories
{
    public class TypeRepository : ITypeRepository
    {
        private readonly TransactionDataContext _transactionDataContext;

        public TypeRepository(TransactionDataContext transactionDataContext)
        {
            _transactionDataContext = transactionDataContext;
        }

        public async Task<IEnumerable<TypeLookup>> ListAllAsync()
        {
            return await _transactionDataContext.Types.ToListAsync();
        }
    }
}
