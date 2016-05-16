using System;
using System.ComponentModel;
using System.Text;
using System.Security.Cryptography;

namespace TryCatch.Lib.DTO
{
    public class ProductFactory
    {
        public static Product CreateProduct(string name, decimal price)
        {
            var product = new Product()
            {
                Id = CreateHash(name + price.ToString()),
                Name = name,
                Price = price
            };

            return product;
        }

        private static string CreateHash(string input)
        {
            byte[] hash;

            using (MD5 md5 = MD5.Create())
            {
                hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
            }

            return BitConverter.ToString(hash).Replace("-", string.Empty);
        }
    }
}