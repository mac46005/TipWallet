using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TipWallet.Models;
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

        public DepositModel Deposit { get; set; } = new DepositModel();

        ///////////////Buttons///////////////
        /// <summary>
        /// This will add the funds to the depoRepo table
        /// And return to the MainView
        /// </summary>
        public ICommand AddFunds => new Command(async () =>
        {
            await _depoRepo.AddOrUpdate(Deposit);
            await Navigation.PopAsync();
        });

    }
}
