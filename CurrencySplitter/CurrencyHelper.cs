namespace CurrencySplitter
{
    class CurrencyHelper
    {
        //Convert currency to copper, divide by number of recipients, convert to least amount of change.
        public static Currency DivideCurrencyByMembers(Currency wealth, int players)
        {
            if (players > 0)
            {
                Currency results = new Currency();
                results.Copper= ConvertCurrencyToCopper(wealth).Copper / players;
                return results;
            }
            else
            {
                System.Windows.MessageBox.Show("You tried to divide by zero.  Good for you.");
                return DivideCurrencyByMembers(wealth, 1);
            }
        }

        //Convert total amount into copper
        public static Currency ConvertCurrencyToCopper(Currency wealth)
        {
            Currency results = new Currency();
            results.Copper = wealth.Platinum * CurrencyExchange.PLATINUM;
            results.Copper += wealth.Gold * CurrencyExchange.GOLD;
            results.Copper += wealth.Electrum * CurrencyExchange.ELECTRUM;
            results.Copper += wealth.Silver * CurrencyExchange.SILVER;
            results.Copper += wealth.Copper;
            return results;
        }
    }
}
