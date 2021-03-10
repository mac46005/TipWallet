using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TipWallet.Models;
using TipWallet.Repository;
using TipWallet.ViewModels;
using TipWallet.Views;
using Xamarin.Forms;

namespace TipWallet.ViewsModels
{
    public class EditDeleteViewModel : ViewModel
    {
        DepositRepository _depoRepo;
        WithdrawRepository _withRepo;
        public EditDeleteViewModel(DepositRepository depoRepo,WithdrawRepository withRepo)
        {
            _depoRepo = depoRepo;
            _withRepo = withRepo;
        }
        public IBankLog Transaction { get; set; }
        public ICommand EditButton => new Command(async () =>
        {
            if (Transaction is DepositModel)
            {
                var v = Resolver.Resolve<DepositView>();
                v.BindingContext = Resolver.Resolve<DepositViewModel>();
                var vm = v.BindingContext as DepositViewModel;
                vm.DepositModel = (DepositModel)Transaction;
                await Navigation.PushAsync(v);
            }
            else
            {
                var v = Resolver.Resolve<WithdrawView>();
                v.BindingContext = Resolver.Resolve<WithdrawViewModel>();
                var vm = v.BindingContext as WithdrawViewModel;
                vm.WithdrawModel = (WithdrawModel)Transaction;
                await Navigation.PushAsync(v);
            }
        });


        public ICommand DeleteButton => new Command(async () =>
        {
            if (Transaction is DepositModel)
            {
                await _depoRepo.DeleteItem((DepositModel)Transaction);
                await Navigation.PopToRootAsync();
            }
            else
            {
                await _withRepo.DeleteItem((WithdrawModel)Transaction);
                await Navigation.PopToRootAsync();
            }
        });
    }
}
