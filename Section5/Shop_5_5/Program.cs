namespace Shop_5_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] productNames = 
            {
                "Laptop", "Smartphone", "Headphones", "Keyboard", "Monitor", 
            };

            float[] prices =
            {
                180f, 50f, 14f, 19f, 100f
            };
            
            Customer customer = new Customer();
            Seller seller = new Seller();

            for (int i = 0; i < productNames.Length; i++)
            {
                seller.AddProduct(new Product(productNames[i], prices[i]));
            }


        }
    }
}
