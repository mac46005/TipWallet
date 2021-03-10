using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TipWallet.Models
{
    public class DepositModel : IBankLog
    {
        [PrimaryKey,AutoIncrement,NotNull]
        public int Id { get; set; }
        [NotNull]
        public decimal Amount { get; set; }
        [NotNull]
        public DateTime TimeStamp { get; set; } = DateTime.Now;
        public string Description { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
