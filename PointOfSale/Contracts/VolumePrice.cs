namespace PointOfSale.Contracts
{
    public class VolumePrice
    {
        public int Size { get; }

        public decimal Price { get; }

        public VolumePrice(decimal price, int size)
        {
            Price = price;
            Size = size;
        }
    }
}
