namespace PointOfSale.Domain
{
    internal class ReceiptLine
    {
        private readonly Product _product;
        private int _productCount;

        public ReceiptLine(Product product)
        {
            _product = product;
            _productCount = 0;
        }

        public void AddProduct()
        {
            _productCount++;
        }
        
        public decimal CalculateTotalPrice()
        {
            var volume = _product.Volume;
            
            var productsCount = _productCount % volume.Size;
            var volumesCount = _productCount / volume.Size;;

            return volumesCount * volume.Price + productsCount * _product.Price;
        }

        public override string ToString()
        {
            return $"{_product.Code,-3} x{_productCount,-3} {CalculateTotalPrice(),-5:N}";
        }
    }
}