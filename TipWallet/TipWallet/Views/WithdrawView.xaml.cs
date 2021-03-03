using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TipWallet.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TipWallet.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WithdrawView : ContentPage
    {
        public WithdrawView(WithdrawViewModel vm)
        {
            InitializeComponent();
            vm.Navigation = Navigation;
            BindingContext = vm;
        }
    }
}