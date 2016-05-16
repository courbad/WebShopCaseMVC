using System;
using System.Collections.Generic;

namespace TryCatch.Lib.DTO
{
    public class Order
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string HouseNumber { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Email { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}