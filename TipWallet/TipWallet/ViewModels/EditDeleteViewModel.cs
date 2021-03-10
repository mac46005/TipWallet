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
            }
            else
            {

            }
        });

        public ICommand DeleteButton => new Command(async () =>
        {

        });
    }
}
