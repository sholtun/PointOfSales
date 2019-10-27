using System;
using System.Collections.Generic;
using System.Text;
using PointOfSale.Contracts;
using PointOfSale.Domain;

namespace PointOfSale
{
    internal static class ModelConversionExt
    {
        public static Product ToProduct(this ProductPrice price)
        {
            return new Product(price.ProductCode, 
                price.Price, 
                price.VolumePrice?.ToVolume() ?? Volume.None);
        }

        private static Volume ToVolume(this VolumePrice price)
        {
            return new Volume(price.Price, price.Size);
        }
    }
}
