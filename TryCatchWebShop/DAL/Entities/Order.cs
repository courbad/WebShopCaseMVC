using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TryCatchWebShop.DAL
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; }

        [StringLength(10)]
        public string Title { get; set; }

        [Required, StringLength(66)]
        public string FirstName { get; set; }

        [Required, StringLength(66)]
        public string LastName { get; set; }

        [Required, StringLength(66)]
        public string Address { get; set; }

        [StringLength(10)]
        public string HouseNumber { get; set; }

        [Required, StringLength(10)]
        public string ZipCode { get; set; }

        [Required, StringLength(24)]
        public string City { get; set; }

        [Required, StringLength(55)]
        public string EMail { get; set; }

    }
}