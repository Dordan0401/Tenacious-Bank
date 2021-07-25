using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tenacious.Data;

namespace Tenacious.Models
{
    public class BankAcctCreate
    {
        [Required]
        public string OwnerFirst { get; set; }
        [Required]
        public string OwnerLast { get; set; }
        [Required]
        public decimal InitialDeposit { get; set; }
        [Required]
        public AccountType AccountType { get; set; }
    }
}
