using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TipWallet.Models;
using TipWallet.Repository;
using Xamarin.Forms;

namespace TipWallet.ViewModels
{
    public class WithdrawViewModel : ViewModel
    {
        WithdrawRepository _withdrawRepo;
        public WithdrawViewModel(WithdrawRepository withdrawRepo)
        {
            _withdrawRepo = withdrawRepo;
        }
        public WithdrawModel WithdrawModel { get; set; }

        public ICommand SubmitButton => new Command(async () =>
        {
            await _withdrawRepo.AddItem(WithdrawModel);
            await Navigation.PopAsync();
        });
    }
}
