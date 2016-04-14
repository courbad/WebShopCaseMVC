using System.Xml.Serialization;

namespace TryCatchWebShop.Models
{
    [XmlType("Product")]
    public class ProductVM
    {
        // I switched to this because newly created guids on app start don't match products in the cart anymore
        // In an actual webshop it would a more refined approach with google friendly IDs
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}