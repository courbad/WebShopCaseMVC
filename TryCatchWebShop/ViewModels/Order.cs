using System.ComponentModel.DataAnnotations;

namespace TryCatch.Web.ViewModels
{
    public class Order
    {
        [Required, StringLength(10)]
        public string Title { get; set; }

        [Required, StringLength(66)]
        public string FirstName { get; set; }

        [Required, StringLength(66)]
        public string LastName { get; set; }

        [Required, StringLength(66)]
        public string Address { get; set; }

        [StringLength(10)]
        public string HouseNumber { get; set; }

        [Required]
        [DataType(DataType.PostalCode)]
        [StringLength(12)]
        public string ZipCode { get; set; }

        [Required, StringLength(24)]
        public string City { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        public string[] ProductIds { get; set; }
    }
}