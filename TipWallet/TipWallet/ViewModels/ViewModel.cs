using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace TipWallet.ViewModels
{
    public abstract class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(params string[] propteries)
        {
            foreach (var prop in propteries)
            {
                PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(prop));
            }
        }

        public INavigation Navigation { get; set; }
    }
}
