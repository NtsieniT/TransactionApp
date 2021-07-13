using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Transaction.Domain.Models.Lookups;

namespace Transaction.Domain.Models
{
    public class Transactions : BaseEntity
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string CellPhone { get; set; }
        public decimal? AmountTotal { get; set; }
        public TypeLookup Type { get; set; }
        public int TypeId { get; set; }
    }
}
