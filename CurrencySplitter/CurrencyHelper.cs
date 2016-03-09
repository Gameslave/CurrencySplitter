using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencySplitter
{
    class CurrencyHelper
    {
        //Converts total value in copper to standard currencies
        public static Currency ConvertCopperToBest(int copper)
        {
            Currency wealth = new Currency();

            wealth.Platinum = CalculateCurrencyAmount(copper, CurrencyExchange.PLATINUM);
            copper -= (wealth.Platinum * CurrencyExchange.PLATINUM);

            wealth.Gold = CalculateCurrencyAmount(copper, CurrencyExchange.GOLD);
            copper -= (wealth.Gold * CurrencyExchange.GOLD);

            wealth.Electrum = CalculateCurrencyAmount(copper, CurrencyExchange.ELECTRUM);
            copper -= (wealth.Electrum * CurrencyExchange.ELECTRUM);

            wealth.Silver = CalculateCurrencyAmount(copper, CurrencyExchange.SILVER);
            copper -= (wealth.Silver * CurrencyExchange.SILVER);

            if (copper > 0)
                wealth.Copper = copper;

            return wealth;
        }

        //Helper to assist in conversion from copper to higher value coins
        public static int CalculateCurrencyAmount(int copper, int conversion)
        {
            int amount = 0;
            while (copper >= conversion)
            {
                amount++;
                copper -= conversion;
            }
            return amount;
        }

        //Convert currency to copper, divide by number of recipients, convert to least amount of change.
        public static Currency DivideCurrencyByMembers(Currency wealth, int players)
        {
            if (players > 0)
            {
                int copper = ConvertCurrencyToCopper(wealth);
                copper = copper / players;
                return ConvertCopperToBest(copper);
            }
            else
            {
                System.Windows.MessageBox.Show("You tried to divide by zero.  Good for you.");
                return DivideCurrencyByMembers(wealth, 1);
            }
        }

        //Convert total amount into copper
        public static int ConvertCurrencyToCopper(Currency wealth)
        {
            int totalWealth = 0;
            totalWealth = wealth.Platinum * CurrencyExchange.PLATINUM;
            totalWealth += wealth.Gold * CurrencyExchange.GOLD;
            totalWealth += wealth.Electrum * CurrencyExchange.ELECTRUM;
            totalWealth += wealth.Silver * CurrencyExchange.SILVER;
            totalWealth += wealth.Copper;
            return totalWealth;
        }
    }
}
