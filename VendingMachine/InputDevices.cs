﻿//////////////////////////////////////////////////////////////////////
//      Vending Machine (Actuators.cs)                              //
//      Written by Masaaki Mizuno, (c) 2006, 2007, 2008, 2010, 2011 //
//                      for Learning Tree Course 123P, 252J, 230Y   //
//                 also for KSU Course CIS501                       //  
//////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine
{
    // For each class, you can (must) add fields and overriding constructors

    public class CoinInserter
    {
        // add a field to specify an object that CoinInserted() will firstvisit
        Coin coin;
        // rewrite the following constructor with a constructor that takes an object
        // to be set to the above field
        public CoinInserter(Coin coin)
        {
            this.coin = coin;
        }
        public void CoinInserted()
        {
            // You can add only one line here
            coin.AddCoin();
        }

    }

    public class PurchaseButton
    {
        // add a field to specify an object that ButtonPressed() will first visit
        Can can;
        public PurchaseButton(Can can)
        {
            this.can = can;
        }
        public void ButtonPressed()
        {
            // You can add only one line here
            can.Purchase();
        }
    }

    public class CoinReturnButton
    {
        // add a field to specify an object that Button Pressed will visit
        // replace the following default constructor with a constructor that takes
        // an object to be set to the above field
        Controller controller;
        public CoinReturnButton(Controller controller)
        {
            this.controller = controller;
        }
        public void ButtonPressed()
        {
            // You can add only one lines here
            controller.ReturnCoins();
        }
    }
}
