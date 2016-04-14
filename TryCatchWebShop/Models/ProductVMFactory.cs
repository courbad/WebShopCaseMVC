using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace TryCatchWebShop.Models
{
    public class ProductVMFactory
    {
        public static ProductVM CreateProduct(string name, decimal price)
        {
            var product = new ProductVM()
            {
                Id = CreateHash(name + price.ToString()),
                Name = name,
                Price = price
            };

            return product;
        }

        private static string CreateHash(string input)
        {

            byte[] encoded = new UTF8Encoding().GetBytes(input);
            byte[] hash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(encoded);

            return BitConverter.ToString(hash)
               .Replace("-", string.Empty)
               .ToLower();
        }
    }
}