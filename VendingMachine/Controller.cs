using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class Controller
    {
        int amount;
        Can[] cans;
        List<Coin> coins;
        TimerLight noChangeLight;
        AmountDisplay amountDisplay;

        public Controller(Can[] cans, List<Coin> coins, TimerLight noChangeLight, AmountDisplay amountDisplay)
        {
            this.cans = cans;
            this.coins = coins;
            this.noChangeLight = noChangeLight;
            this.amountDisplay = amountDisplay;

            amount = 0;
        }
        
        public void UpdateAmount(int value)
        {
            amount += value;
            amountDisplay.DisplayAmount(amount);
            foreach(Can can in cans)
            {
                can.UpdatePurchasableLight(amount);
            }
        }

        private void ResetDisplays()
        {
            amount = 0;
            amountDisplay.DisplayAmount(amount);
            foreach (Can can in cans) can.TurnOffPurchasableLight();
        }

        public bool TryToReturnChange(int price)
        {
            int change = amount - price;
            for (int i = coins.Count - 1; i >= 0; i--)
            {
                change = coins[i].CalcNumCoinsToReturn(change);
            }
            if (change == 0)
            {
                foreach(Coin coin in coins)
                {
                    coin.ReturnCoins();
                }
                ResetDisplays();
                return true;
            }
            else
            {
                noChangeLight.TurnOn3Sec();
                return false;
            }

        }

        public void ReturnCoins()
        {
            for (int i = coins.Count - 1; i >= 0; i--)
            {
                amount = coins[i].CalcNumCoinsToReturn(amount);
            }
            foreach(Coin coin in coins)
            {
                coin.ReturnCoins();
            }
            ResetDisplays();
        }
    }
}
