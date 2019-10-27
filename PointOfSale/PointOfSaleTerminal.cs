using System;
using System.Linq;
using System.Runtime.CompilerServices;
using PointOfSale.Contracts;
using PointOfSale.Domain;

[assembly: InternalsVisibleTo("PointOfSaleTests")]
namespace PointOfSale
{
    public class PointOfSaleTerminal
    {
        private Pricing _pricing;
        private Receipt _receipt =  new Receipt();

        public PointOfSaleTerminal(params ProductPrice[] prices)
        {
            SetPrices(prices);
        }

        public decimal CalculateTotal()
        {
            return _receipt.CalculateTotalPrice();
        }

        public void CreateNewReceipt()
        {
            _receipt = new Receipt();
        }

        public void SetPrices(params ProductPrice[] productPrices)
        {
            if (!_receipt.IsEmpty)
            {
                throw new PosException("Receipt is not empty. Create a new one to change prices.");
            }

            var products = productPrices.Select(p => p.ToProduct());
            _pricing = new Pricing(products);
        }

        public void Scan(string productCode)
        {
            if (!_pricing.TryGetProduct(productCode, out var price))
            {
                throw new PosException("Product price is missing");
            }
            _receipt.AddProduct(price);
        }

        public string PrintReceipt()
        {
            return _receipt.ToString();
        }
    }
}
