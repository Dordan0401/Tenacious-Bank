using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tenacious.Models
{
    public class BankAcctDeposit
    {
        public decimal InitialBalance { get; set; }
        [Required]
        public decimal DepositAmount { get; set; }
        public decimal NewBalance
        {
            get
            {
                return InitialBalance + DepositAmount;
            }
        }
    }
}
