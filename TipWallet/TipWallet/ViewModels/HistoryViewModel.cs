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

        public ObservableCollection<IBankLog> Transactions { get; set; }
        public async Task LoadData()
        {
            Transactions = new ObservableCollection<IBankLog>();
            var with = await _withRepo.GetItems();
            with.ForEach(x => { Transactions.Add(x); });
            var depo = await _depoRepo.GetItems();
            depo.ForEach(x => { Transactions.Add(x); });
        }
        private DetailsViewModel CreateDetail(IBankLog transaction)
        {
            var vm = Resolver.Resolve<DetailsViewModel>();
            vm.Transaction = transaction;
            return vm;
        }
    }
}
