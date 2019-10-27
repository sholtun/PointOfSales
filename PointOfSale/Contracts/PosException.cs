using System;

namespace PointOfSale.Contracts
{
    public class PosException : Exception
    {
        public PosException(string message) : base(message)
        {
            
        }
    }
}
