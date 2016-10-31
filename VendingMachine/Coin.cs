using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class Coin
    {
        private int numCoins;
        private int value;
        private int numCoinsToReturn;
        CoinDispenser coinDispenser;
        Controller controller;

        public int NumCoins
        {
            get { return numCoins; }
        }

        public Coin(Controller c, CoinDispenser cd, int n, int v)
        {
            controller = c;
            coinDispenser = cd;
            numCoins = n;
            value = v;
        }

        public void AddCoin()
        {
            numCoins++;
            controller.UpdateAmount(value);
        }

        public int CalcNumCoinsToReturn(int change)
        {
            numCoinsToReturn = change / value;
            if(numCoins < numCoinsToReturn)
            {
                numCoinsToReturn = numCoins;
            }
            return change - (numCoinsToReturn * value);
        }

        public void ReturnCoins()
        {
            coinDispenser.Actuate(numCoinsToReturn);
            numCoins -= numCoinsToReturn;
        }
    }
}
