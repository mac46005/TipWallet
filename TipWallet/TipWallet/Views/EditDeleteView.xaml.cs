using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TipWallet.ViewsModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TipWallet.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditDeleteView : ContentPage
    {
        public EditDeleteView(EditDeleteViewModel vm)
        {
            InitializeComponent();
            vm.Navigation = Navigation;
            BindingContext = vm;
        }
    }
}