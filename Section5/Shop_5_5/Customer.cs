using System;
using System.Collections.Generic;

namespace Shop_5_5
{
    internal class Customer
    {
        private List<Product> _products = new List<Product>();

        public void Buy(Seller seller, int productNumber)
        {
            float price = seller.GetProductPrice(productNumber);

            if(price > Balance)
            {
                Console.WriteLine("No enought money");
                return;
            }

            int productIndex = productNumber - 1;
            seller.Sell(productIndex);
            Balance -= price;
        }

        public float Balance { get; private set; }
    }
}