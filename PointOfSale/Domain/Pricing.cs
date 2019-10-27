using System.Collections.Generic;
using System.Linq;

namespace PointOfSale.Domain
{
    internal class Pricing
    {
        private readonly Dictionary<string, Product> _products;
        public Pricing(IEnumerable<Product> productPrices)
        {
            _products = productPrices.ToDictionary(x => x.Code);
        }

        public bool TryGetProduct(string productCode, out Product product)
        {
            return _products.TryGetValue(productCode, out product);
        }
    }
}