using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TipWallet.Repository;
using Xamarin.Forms;

namespace TipWallet.ViewModels
{
    public class DepositViewModel : ViewModel
    {
        DepositRepository _depoRepo;
        public DepositViewModel(DepositRepository depoRepo)
        {
            _depoRepo = depoRepo;
        }

        ///////////////Buttons///////////////

        /// <summary>
        /// This will add the funds to the depoRepo table
        /// </summary>
        public ICommand AddFunds => new Command(async () =>
        {

        });

    }
}
