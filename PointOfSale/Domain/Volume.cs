namespace PointOfSale.Domain
{
    internal class Volume
    {
        public decimal Price { get; }
        public int Size { get; }

        public Volume(decimal price, int size)
        {
            Price = price;
            Size = size;
        }

        public static Volume None => new Volume(0M, int.MaxValue);
    }
}