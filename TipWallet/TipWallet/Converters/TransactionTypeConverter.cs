using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using TipWallet.Models;
using Xamarin.Forms;

namespace TipWallet.Converters
{
    public class TransactionTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            IBankLog bankLog = (IBankLog)value;
            if (bankLog is DepositModel)
            {
                return Color.LightGreen;
            }
            else
            {
                return Color.Salmon;
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
