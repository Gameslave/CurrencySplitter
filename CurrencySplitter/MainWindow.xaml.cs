using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CurrencySplitter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //Pull information from text boxes
        private Currency GetCurrency()
        {
            Currency wealth = new Currency();

            int.TryParse(tbCP.Text,out wealth.Copper);
            int.TryParse(tbGP.Text,out wealth.Gold);
            int.TryParse(tbSP.Text,out wealth.Silver);
            int.TryParse(tbEP.Text,out wealth.Electrum);
            int.TryParse(tbPP.Text,out wealth.Platinum);

            return wealth;
        }

        //Create window to show results
        private void CreateResults(Currency wealth)
        {
            results window = new results();
            window.Owner = this;
            window.tbCP.Text = wealth.Copper.ToString();
            window.tbSP.Text = wealth.Silver.ToString();
            window.tbEP.Text = wealth.Electrum.ToString();
            window.tbGP.Text = wealth.Gold.ToString();
            window.tbPP.Text = wealth.Platinum.ToString();

            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;

            window.ShowDialog();
        }

        //<events>
        //Handles click event for splitting currency
        private void btnSplit_Click(object sender, RoutedEventArgs e)
        {
            int numberToSplit = 1;
            int.TryParse(tbSplitAmount.Text, out numberToSplit);
            Currency wealth = GetCurrency();
            CreateResults(CurrencyHelper.DivideCurrencyByMembers(wealth, numberToSplit));
        }

        //Handles click event for converting currency
        private void btnConvert_Click(object sender, RoutedEventArgs e)
        {
            Currency wealth = GetCurrency();
            CreateResults(CurrencyHelper.ConvertCopperToBest(CurrencyHelper.ConvertCurrencyToCopper(wealth)));
        }

        private void btnTransact_Click(object sender, RoutedEventArgs e)
        {
            Currency wealth = GetCurrency();
            Transaction transact = new Transaction(wealth.Platinum, wealth.Gold, wealth.Electrum, wealth.Silver, wealth.Copper);
            transact.Owner = this;
            transact.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            transact.ShowDialog();
        }

        private void tbGotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tmp = (TextBox)sender;
            if(tmp.Text.Equals("0"))
            {
                tmp.Text = "";
            }
        }

        private void tbLostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tmp = (TextBox)sender;
            if(tmp.Text.Equals("0") || string.IsNullOrWhiteSpace(tmp.Text))
            {
                tmp.Text = "0";
            }
        }
        //</events>
    }
}
