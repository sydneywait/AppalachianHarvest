using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AppalachianHarvest.Models
{
    public class Producer
    {
        [Key]
        public int ProducerId { get; set; }
        [Required]
        [Display(Name = "First Name")]

        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]

        public string LastName { get; set; }
        [NotMapped]
        [Display(Name = "Name")]

        public string FullName { get { return this.FirstName + " " + this.LastName; } }

        [Required]
        [Display(Name = "Business Name")]

        public string BusinessName { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        [RegularExpression(@"^\d{3}-\d{3}-\d{4}$", ErrorMessage = "Enter a valid phone number (xxx-xxx-xxxx)")] public string Phone { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Mailing Address")]

        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        [DataType(DataType.PostalCode)]
        [Display(Name = "Zip Code")]
        public int ZipCode { get; set; }
        public byte[] ProducerImage { get; set; }
        public bool IsActive { get; set; }
        public Producer()
        {
            IsActive = true;
        }

        [NotMapped]
        public IFormFile ImageUpload { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
