namespace CurrencySplitter
{
    class Currency
    {
        public int Platinum;
        public int Gold;
        public int Electrum;
        public int Silver;
        public int Copper;

        //Converts total value in copper to standard currencies
        public Currency ConvertCopperToBest(ConversionOptions options)
        {
            Currency wealth = new Currency();
            int tmpCopper = Copper;

            if (options.Platinum)
            {
                wealth.Platinum = CalculateCurrencyAmount(tmpCopper, CurrencyExchange.PLATINUM);
                tmpCopper -= (wealth.Platinum * CurrencyExchange.PLATINUM);
            }

            if (options.Gold)
            {
                wealth.Gold = CalculateCurrencyAmount(tmpCopper, CurrencyExchange.GOLD);
                tmpCopper -= (wealth.Gold * CurrencyExchange.GOLD);
            }

            if (options.Electrum)
            {
                wealth.Electrum = CalculateCurrencyAmount(tmpCopper, CurrencyExchange.ELECTRUM);
                tmpCopper -= (wealth.Electrum * CurrencyExchange.ELECTRUM);
            }

            if (options.Silver)
            {
                wealth.Silver = CalculateCurrencyAmount(tmpCopper, CurrencyExchange.SILVER);
                tmpCopper -= (wealth.Silver * CurrencyExchange.SILVER);
            }

            if (tmpCopper > 0)
                wealth.Copper = tmpCopper;

            return wealth;
        }

        //Helper to assist in conversion from copper to higher value coins
        private int CalculateCurrencyAmount(int copper, int conversion)
        {
            int amount = 0;
            while (copper >= conversion)
            {
                amount++;
                copper -= conversion;
            }
            return amount;
        }
    }
}
