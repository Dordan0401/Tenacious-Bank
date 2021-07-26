using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tenacious.Data
{
    public enum AccountType { Checking, CorporateInvest, IndividualInvest }
    public class BankAcct
    {
        [Key]
        public int AccountNumber { get; set; }
        [Required]
        public Guid AccountOwnerId { get; set; }
        [Required]
        public string OwnerFirst { get; set; }
        [Required]
        public string OwnerLast { get; set; }
        [Required]
        [Range(0, 999999999)]
        public decimal Balance { get; set; }
        [Required]
        public AccountType AccountType { get; set; }
    }
}
