using System.Windows;
using System.Windows.Controls;

namespace CurrencySplitter
{
    /// <summary>
    /// Interaction logic for Transaction.xaml
    /// </summary>
    public partial class Transaction : Window
    {
        private Currency wealth = new Currency();
        private Currency cost = new Currency();

        public Transaction()
        {
            InitializeComponent();
        }

        public Transaction(int Platinum, int Gold, int Electrum, int Silver, int Copper)
        {
            InitializeComponent();

            this.tbPPWealth.Text = Platinum.ToString();
            this.tbGPWealth.Text = Gold.ToString();
            this.tbEPWealth.Text = Electrum.ToString();
            this.tbSPWealth.Text = Silver.ToString();
            this.tbCPWealth.Text = Copper.ToString();
        }

        private void GetCurrency()
        {
            int.TryParse(tbCPWealth.Text, out wealth.Copper);
            int.TryParse(tbGPWealth.Text, out wealth.Gold);
            int.TryParse(tbSPWealth.Text, out wealth.Silver);
            int.TryParse(tbEPWealth.Text, out wealth.Electrum);
            int.TryParse(tbPPWealth.Text, out wealth.Platinum);

            int.TryParse(tbCPCost.Text, out cost.Copper);
            int.TryParse(tbGPCost.Text, out cost.Gold);
            int.TryParse(tbSPCost.Text, out cost.Silver);
            int.TryParse(tbEPCost.Text, out cost.Electrum);
            int.TryParse(tbPPCost.Text, out cost.Platinum);
        }

        private ConversionOptions GetConversion()
        {
            ConversionOptions options = new ConversionOptions();
            options.Platinum = (bool)cbPlatinum.IsChecked;
            options.Gold = (bool)cbGold.IsChecked;
            options.Electrum = (bool)cbElectrum.IsChecked;
            options.Silver = (bool)cbSilver.IsChecked;
            options.Copper = (bool)cbCopper.IsChecked;

            return options;
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            GetCurrency();
            int copperWealth, copperCost;
            copperWealth = CurrencyHelper.ConvertCurrencyToCopper(wealth).Copper;
            copperCost = CurrencyHelper.ConvertCurrencyToCopper(cost).Copper;
            copperWealth -= copperCost;
            wealth = new Currency(copper: copperWealth).ConvertCopperToBest(GetConversion());
            results window = new results();

            window.tbPP.Text = wealth.Platinum.ToString();
            window.tbGP.Text = wealth.Gold    .ToString();
            window.tbEP.Text = wealth.Electrum.ToString();
            window.tbSP.Text = wealth.Silver  .ToString();
            window.tbCP.Text = wealth.Copper  .ToString();

            window.Owner = this;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;

            window.ShowDialog();
        }

        private void tbGotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tmp = (TextBox)sender;
            if (tmp.Text.Equals("0"))
            {
                tmp.Text = "";
            }
        }

        private void tbLostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tmp = (TextBox)sender;
            if (tmp.Text.Equals("0") || string.IsNullOrWhiteSpace(tmp.Text))
            {
                tmp.Text = "0";
            }
        }
    }
}
