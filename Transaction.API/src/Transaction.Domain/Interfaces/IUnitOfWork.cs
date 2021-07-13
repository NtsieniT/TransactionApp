using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Transaction.Domain.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        ITransactionRepository TransactionRepository { get; }
        ITypeRepository TypeRepository { get; }


        Task<bool> Complete();
    }
}
