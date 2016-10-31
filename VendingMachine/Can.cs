using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class Can
    {
        private int price;
        private int numCans;
        Controller controller;
        Light purchasableLight;
        Light soldoutLight;
        CanDispenser canDispenser;

        public int NumCans
        {
            get { return numCans; }
        }

        public Can(Controller c, CanDispenser cd, Light purl, Light sol, int p, int nc)
        {
            controller = c;
            purchasableLight = purl;
            canDispenser = cd;
            soldoutLight = sol;
            price = p;
            numCans = nc;
        }

        public void UpdatePurchasableLight(int amount)
        {
            if((amount >= price) && (numCans > 0))
            {
                purchasableLight.TurnOn();
            }
        }

        public void Purchase()
        {
            if(purchasableLight.IsOn())
            {
                if(controller.TryToReturnChange(this.price))
                {
                    canDispenser.Actuate();
                    numCans--;
                    if(numCans == 0)
                    {
                        soldoutLight.TurnOn();
                    }
                }
            }
        }

        public void TurnOffPurchasableLight()
        {
            purchasableLight.TurnOff();
        }
    }
}
