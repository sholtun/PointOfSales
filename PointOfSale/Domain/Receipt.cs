using System;
using System.Collections.Generic;
using System.Linq;

namespace PointOfSale.Domain
{
    internal class Receipt
    {
        private readonly Dictionary<string, ReceiptLine> _lines = new Dictionary<string, ReceiptLine>();

        public decimal CalculateTotalPrice()
        {
            return _lines.Sum(pair => pair.Value.CalculateTotalPrice());
        }

        public void AddProduct(Product product)
        {
            if (!_lines.TryGetValue(product.Code, out var line))
            {
                line = new ReceiptLine(product);
                _lines.Add(product.Code, line);
            }

            line.AddProduct();
        }

        public bool IsEmpty => _lines.Count == 0;

        public override string ToString()
        {
            return string.Join(Environment.NewLine,
                _lines.Values.Select(l => l.ToString()));
        }
    }
}
