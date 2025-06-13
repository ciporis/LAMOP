using System;
using System.Collections.Generic;

namespace Shop_5_5
{
    internal class Seller
    {
        private List<Product> _products = new List<Product>();

        public float Balance { get; private set; }

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public void Sell(int productNumber)
        {
            int productIndex = productNumber - 1;
            Balance += _products[productIndex].Price;
            _products.RemoveAt(productIndex);
        }

        public float GetProductPrice(int productNumber)
        {
            int productIndex = productNumber - 1;
            return _products[productIndex].Price;
        }

        public void ShowAllProducts()
        {
            Console.WriteLine("I have this goods:");

            for (int i = 0; i < _products.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {_products[i]}");
            }
        }
    }
}
