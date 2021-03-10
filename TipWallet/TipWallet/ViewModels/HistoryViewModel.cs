using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TipWallet.Models;
using TipWallet.Repository;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using TipWallet.Views;
using TipWallet.ViewsModels;

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

            //Runs the LoadData method to fill the list view
            Task.Run(async () => await LoadData());
        }

        /// <summary>
        /// A list of viewmodels that wraps a model in it.
        /// </summary>
        public ObservableCollection<TransactionViewModel> Transactions { get; set; }


        /// <summary>
        /// Retrieves all values from both repo and with tables and combines it into one list
        /// </summary>
        /// <returns>Void</returns>
        public async Task LoadData()
        {
            Transactions = new ObservableCollection<TransactionViewModel>();
            var with = await _withRepo.GetItems();
            with.ForEach(x => { Transactions.Add(CreateTransVM(x)); });
            var depo = await _depoRepo.GetItems();
            depo.ForEach(x => { Transactions.Add(CreateTransVM(x)); });
        }





        /// <summary>
        /// Creates a TVM for use in the listview
        /// </summary>
        /// <param name="transaction">IBankLog</param>
        /// <returns>TransactionViewModel</returns>
        private TransactionViewModel CreateTransVM(IBankLog transaction)
        {
            var vm = Resolver.Resolve<TransactionViewModel>();
            vm.Transaction = transaction;
            return vm;
        }


        /// <summary>
        /// Selects an item from the list view and sends it to the editdelete view
        /// </summary>
        public TransactionViewModel SelectedItem 
        {
            get => null; 
            set
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await NavigateToPage(value);
                    OnPropertyChanged(nameof(SelectedItem));
                });
                
            }
        }
        /// <summary>
        /// Maybe make a universal version for later use. 
        /// Sends a model to a page
        /// </summary>
        /// <param name="vm"></param>
        /// <returns></returns>
        private async Task NavigateToPage(TransactionViewModel vm)
        {
            if (vm == null)
            {
                return;
            }

            var v = Resolver.Resolve<EditDeleteView>();
            var vBindingContext = v.BindingContext as EditDeleteViewModel;
            vBindingContext.Transaction = vm.Transaction;
            await Navigation.PushAsync(v);
        }
    }
}
