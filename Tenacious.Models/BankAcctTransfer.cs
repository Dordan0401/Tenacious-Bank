using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tenacious.Models
{
    public class BankAcctTransfer
    {
        [Required]
        public int SendingId { get; set; }
        [Required]
        public int RecievingId { get; set; }
        [Required]
        public decimal TransferAmount { get; set; }
    }
}
