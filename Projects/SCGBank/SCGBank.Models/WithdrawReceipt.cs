using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCGBank.Models
{
    public class WithdrawReceipt
    {
        public int AcccountNumber { get; set; }
        public decimal NewBalance { get; set; }
    }
}
