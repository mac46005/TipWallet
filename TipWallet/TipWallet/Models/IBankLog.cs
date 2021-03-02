using System;
using System.Collections.Generic;
using System.Text;

namespace TipWallet.Models
{
    interface IBankLog
    {
        int Id { get; set; }
        decimal Amount { get; set; }
        DateTime TimeStamp { get; set; }

    }
}
