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
        public decimal InitialBalance { get; set; }
        [Required]
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
