using System;
using System.Collections.Generic;
using System.Text;

namespace TipWallet.Models
{
    public class WithdrawModel
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
    }
}
