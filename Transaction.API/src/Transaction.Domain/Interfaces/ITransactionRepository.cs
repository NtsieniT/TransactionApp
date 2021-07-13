using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Transaction.Domain.Models;

namespace Transaction.Domain.Interfaces
{
    public interface ITransactionRepository
    {
        Task<IEnumerable<Models.Transactions>> ListAllAsync();
        Task<Models.Transactions> GetByIdAsync(int id);
        void Add(Models.Transactions transaction);
        void Update(Models.Transactions transaction);
        void Delete(int id);
    }
}
