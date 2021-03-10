using System;
using System.Collections.Generic;
using System.Text;

namespace TipWallet.Models
{
    public interface IBankLog
    {
        int Id { get; set; }
        decimal Amount { get; set; }
        DateTime TimeStamp { get; set; }
        string Description { get; set; }

    }
}
