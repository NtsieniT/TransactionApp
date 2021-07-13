using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Transaction.Domain.Models.Lookups;

namespace Transaction.Domain.Interfaces
{
    public interface ITypeRepository
    {
        Task<IEnumerable<TypeLookup>> ListAllAsync();
    }
}
