using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace TryCatchWebShop.Models
{
    [XmlType("Product")]
    public class ProductVM
    {
        public ProductVM()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }  // In an actual webshop it would be more google friendly ID
        public String Name { get; set; }
        public decimal Price { get; set; }
    }
}