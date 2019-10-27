using System;
using PointOfSale;
using PointOfSale.Contracts;
using PointOfSale.Domain;

namespace Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            var prices = new[]
            {
                new ProductPrice("A", 1.25M, new VolumePrice(3M, 3)),
                new ProductPrice("B", 4.25M),
                new ProductPrice("C", 1.00M, new VolumePrice(5M, 6)),
                new ProductPrice("D", 0.75M)
            };

            var terminal = new PointOfSaleTerminal(prices);
            
            terminal.Scan("A");
            terminal.Scan("A");
            terminal.Scan("A");
            terminal.Scan("A");
            terminal.Scan("C");
            terminal.Scan("D");

            Console.WriteLine(terminal.PrintReceipt());
            Console.WriteLine($"Total Price: {terminal.CalculateTotal()}");

        }
    }
}
