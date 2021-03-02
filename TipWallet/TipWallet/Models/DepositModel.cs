using System;
using System.Collections.Generic;
using System.Text;

namespace TipWallet.Models
{
    public class DepositModel
    {
        public int Id { get; set; }
        public decimal Amouht { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
