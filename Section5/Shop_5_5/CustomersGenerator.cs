﻿using System;

namespace Shop_5_5
{
    internal class CustomersGenerator
    {
        private int _maxBalance = 40000;

        private int _minProductsCount = 1;
        private int _maxProductsCount = 15;

        private Random _random = new Random();
        private int _customersCount;

        public CustomersGenerator(int customersCount)
        {
            _customersCount = customersCount;
        }

        public Customer[] GetCustomers()
        {
            Customer[] customers = new Customer[_customersCount];

            Shop shop = ServiceLocator.GetService<Shop>();
            Product[] products = shop.Products;

            int minProductIndex = 0;
            int maxProductIndex = products.Length - 1;

            for (int i = 0; i < _customersCount; i++)
            {
                int randomProductsCount = _random.Next(_minProductsCount, _maxProductsCount + 1);

                Product[] randomProducts = new Product[randomProductsCount];

                for (int j = 0; j < randomProductsCount; j++)
                {
                    int randomProductIndex = _random.Next(minProductIndex, maxProductIndex + 1);
                    randomProducts[j] = products[randomProductIndex];
                    Total += randomProducts[j].Price;
                }

                int randomBalance = _random.Next(Total, _maxBalance + 1);
                customers[i] = new Customer(randomBalance, randomProducts);
            }

            return customers;
        }

        public int Total { get; private set; }
    }
}
