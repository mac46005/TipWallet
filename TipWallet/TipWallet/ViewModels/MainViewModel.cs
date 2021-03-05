using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TipWallet.Repository;
using TipWallet.Views;
using Xamarin.Forms;
using System.Linq;
using System.Threading.Tasks;

namespace TipWallet.ViewModels
{
    public class MainViewModel : ViewModel
    {
        DepositRepository _depositRepo;
        WithdrawRepository _withdrawRepo;

        public MainViewModel(DepositRepository depoRepo, WithdrawRepository withRepo)
        {
            _depositRepo = depoRepo;
            _withdrawRepo = withRepo;
            _depositRepo.OnObjAdded += (sender, e) => Task.Run(async () => await LoadData());
            Task.Run(async () => await LoadData());
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
        public string Balance { get; set; }

        public async Task LoadData()
        {
            var depoAmount = await _depositRepo.GetAmount();
            var withAmount = await _withdrawRepo.GetAmount();
            Balance = $"{(depoAmount - withAmount):C}";
        }
        public event EventHandler Balancepdated;
    }
}
