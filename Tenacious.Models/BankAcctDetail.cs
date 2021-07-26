using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tenacious.Data;

namespace Tenacious.Models
{
    public class BankAcctDetail
    {
        public int AccountNumber { get; set; }
        public AccountType AccountType { get; set; }
        public string OwnerFirst { get; set; }
        public string OwnerLast { get; set; }
        public decimal Balance { get; set; }
    }
}
