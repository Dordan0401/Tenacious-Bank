using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tenacious.Models
{
    public class BankAcctWithdrawal
    {
        [Required]
        public decimal InitialBalance { get; set; }
        [Required]
        [Range(0, 1000)]
        public decimal WithdrawalAmount { get; set; }
        public decimal NewBalance
        {
            get
            {
                decimal balanceCheck = InitialBalance - WithdrawalAmount;
                if (balanceCheck < 0)
                {
                    return InitialBalance;
                }
                else
                {
                    return balanceCheck;
                }
            }
        }
    }
}
