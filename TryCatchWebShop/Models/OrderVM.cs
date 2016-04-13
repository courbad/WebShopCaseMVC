using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TryCatchWebShop.Models
{
    public class OrderVM
    {
        public string Title { get; set; }  
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string HouseNumber { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string EMail { get; set; }

        public IEnumerable<Guid> ProductIds { get; set; }
    }
}