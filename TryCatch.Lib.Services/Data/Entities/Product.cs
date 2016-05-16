using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TryCatch.Lib.Services.Entities
{
    public class Product
    {
        public Product()
        {
            Guid = Guid.NewGuid();
        }

        [Key]
        public Guid Guid { get; set; } // just to have some key field -> be able to save

        public string Id { get; set; } // ID from products.xml

        [Required, StringLength(255)]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Count { get; set; }

        public virtual Order Order { get; set; }

      }
}