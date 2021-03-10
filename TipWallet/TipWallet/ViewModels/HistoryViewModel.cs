using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TipWallet.Models;
using TipWallet.Repository;
using System.Linq;
using System.Threading.Tasks;

namespace TipWallet.ViewModels
{
    public class HistoryViewModel : ViewModel
    {
        WithdrawRepository _withRepo;
        DepositRepository _depoRepo;

        public HistoryViewModel(WithdrawRepository withRepo,DepositRepository depoRepo)
        {
            _withRepo = withRepo;
            _depoRepo = depoRepo;

            Task.Run(async () => await LoadData());
        }

        public ObservableCollection<TransactionViewModel> Transactions { get; set; }
        public async Task LoadData()
        {
            Transactions = new ObservableCollection<TransactionViewModel>();
            var with = await _withRepo.GetItems();
            with.ForEach(x => { Transactions.Add(CreateTransVM(x)); });
            var depo = await _depoRepo.GetItems();
            depo.ForEach(x => { Transactions.Add(CreateTransVM(x)); });
        }
        private TransactionViewModel CreateTransVM(IBankLog transaction)
        {
            var vm = Resolver.Resolve<TransactionViewModel>();
            vm.Transaction = transaction;
            return vm;
        }
    }
}
