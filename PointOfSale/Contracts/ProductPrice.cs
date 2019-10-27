namespace PointOfSale.Contracts
{
    public class ProductPrice
    {
        public ProductPrice(string productCode, decimal price, VolumePrice volumePrice)
        {
            ProductCode = productCode;
            Price = price;
            VolumePrice = volumePrice;
        }

        public ProductPrice(string productCode, decimal price)
            : this(productCode, price, null)
        {
        }

        public string ProductCode { get; }
        public decimal Price { get; }
        public VolumePrice VolumePrice { get; }
    }
}
