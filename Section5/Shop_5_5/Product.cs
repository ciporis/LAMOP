namespace Shop_5_5
{
    internal class Product
    {
        public Product(string name, float price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; private set; }
        public float Price { get; private set; }
    }
}
