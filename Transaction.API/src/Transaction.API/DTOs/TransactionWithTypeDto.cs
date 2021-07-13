using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Transaction.API.DTOs
{
    public class TransactionWithTypeDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string CellPhone { get; set; }
        public decimal? AmountTotal { get; set; }
        public string Type { get; set; }
        public int TypeId { get; set; }
    }
}
