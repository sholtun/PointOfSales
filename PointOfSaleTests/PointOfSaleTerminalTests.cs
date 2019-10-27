using System;
using System.Collections.Generic;
using System.Linq;
using PointOfSale;
using PointOfSale.Contracts;
using PointOfSale.Domain;
using Xunit;

namespace PointOfSaleTests
{
    public class PointOfSaleTerminalTests
    {
        public static IEnumerable<object[]> Theories => new List<object[]>
        {
            new object[] {new[] {"A", "B", "C", "D", "A", "B", "A"}, 13.25M},
            new object[] {new[] {"C", "C", "C", "C", "C", "C", "C"}, 6M},
            new object[] {new[] {"A", "B", "C", "D"}, 7.25M},
            new object[] {new[] {"C", "A", "C", "A", "C", "A", "C", "A", "C", "C"}, 9.25M},
        };

        private static ProductPrice[] Prices => new[]
        {
            new ProductPrice("A", 1.25M, new VolumePrice(3M, 3)),
            new ProductPrice("B", 4.25M),
            new ProductPrice("C", 1.00M, new VolumePrice(5M, 6)),
            new ProductPrice("D", 0.75M)
        };

        private readonly PointOfSaleTerminal _terminal;

        public PointOfSaleTerminalTests()
        {
            _terminal = new PointOfSaleTerminal(Prices);
        }

        [MemberData(nameof(Theories))]
        [Theory]
        public void ShouldCalculateTotalCorrectly(string[] productCodes, decimal expectedTotalPrice)
        {
            foreach (var code in productCodes)
            {
                _terminal.Scan(code);
            }
            var totalPrice = _terminal.CalculateTotal();
            Assert.Equal(expectedTotalPrice, totalPrice);
        }

        [Fact]
        public void ShouldThrowExceptionOnInvalidProduct()
        {
            Assert.Throws<PosException>(() =>
            {
                _terminal.Scan("NOT_EXIST");
            });
        }

        [Fact]
        public void ShouldThrowExceptionOnPriceChange()
        {
            _terminal.Scan("A");
            Assert.Throws<PosException>(() => { _terminal.SetPrices(new ProductPrice("Z", 10M)); });
        }

        [Fact]
        public void ShouldCreateNewReceipt()
        {
            _terminal.Scan("A");
            _terminal.CreateNewReceipt();
            Assert.Equal(0, _terminal.CalculateTotal());
        }
    }
}