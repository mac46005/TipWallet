using System;
using System.Collections.Generic;
using System.Text;
using TipWallet.Models;

namespace TipWallet.ViewModels
{
    public class TransactionViewModel : ViewModel
    {
        public IBankLog Transaction { get; set; }

    }
}