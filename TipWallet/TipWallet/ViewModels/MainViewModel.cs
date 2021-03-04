using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TipWallet.Repository;
using TipWallet.Views;
using Xamarin.Forms;

namespace TipWallet.ViewModels
{
    public class MainViewModel : ViewModel
    {
        DepositRepository _depositRepo;
        WithdrawRepository _withdrawRepo;

        public MainViewModel(DepositRepository depoRepo,WithdrawRepository withRepo)
        {
            _depositRepo = depoRepo;
            _withdrawRepo = withRepo;
        }
        ///////////////Top Bar Buttons///////////////
        public ICommand Deposit => new Command(async () =>
        {
            await Navigation.PushAsync(Resolver.Resolve<DepositView>());

        });

        public ICommand Withdraw => new Command(async () =>
        {
            await Navigation.PushAsync(Resolver.Resolve<WithdrawView>());

        });

        public ICommand History => new Command(async () =>
        {
            await Navigation.PushAsync(Resolver.Resolve<HistoryView>());

        });
        ///////////////Properties///////////////
        public string Balance 
        { 
            get 
            {
                var depositAmount = 
            } 
        }

    }
}
