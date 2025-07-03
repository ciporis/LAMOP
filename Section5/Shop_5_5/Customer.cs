using System;

namespace Shop_5_5{
    internal class Customer
    {
        public Customer(int balance, Product[] producsts)
        {
            Balance = balance;

            foreach (Product product in producsts)
            {
                Total += product.Price;
            }

            Products = producsts;
        }

        public void Buy(Product product)
        {
            Balance -= product.Price;
        }

        public int Balance { get; private set; }
        public Product[] Products { get; private set; }
        public int ProductsCount => Products.Length;
        public int Total { get; private set; }
    }
}