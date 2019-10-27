namespace PointOfSale.Domain
{
    internal class Product
    {
        public string Code { get; }
        public decimal Price { get; }
        public Volume Volume { get; }

        public Product(string code, decimal price, Volume volume)
        {
            Code = code;
            Price = price;
            Volume = volume;
        }
    }
}