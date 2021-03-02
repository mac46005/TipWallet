using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TipWallet.Models
{
    public class WithdrawModel : IBankLog
    {
        [PrimaryKey,AutoIncrement,NotNull]
        public int Id { get; set; }
        public int TypeId { get; set; }
        [NotNull]
        public decimal Amount { get; set; }
        public string Description { get; set; }
        [NotNull]
        public DateTime TimeStamp { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
