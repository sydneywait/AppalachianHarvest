using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AppalachianHarvest.Models
{
    public class Product
    {
        [Key]
        [Display(Name="Product")]
        public int ProductId { get; set; }
        [Required]
        [StringLength(55, ErrorMessage = "Please shorten the product name to 55 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Select a Producer")]
        [Display(Name = "Producer")]
        public int ProducerId { get; set; }
        public Producer Producer { get; set; }

        [Required(ErrorMessage = "Please Select a Product Category")]
        [Display(Name = "Product Type")]
        public int ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }
        [Required(ErrorMessage = "Please Select a location in the store")]
        [Display(Name = "Location")]

        public int ShelfId { get; set; }
        public Shelf Shelf { get; set; }
        [Required]
        [Display(Name = "Qty.")]

        public int Quantity { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double Price { get; set; }
        [Display(Name = "Image")]

        public byte[] Image { get; set; }
        [NotMapped]
        public IFormFile ImageUpload { get; set; }
        [Required]
        [Display(Name = "Organic")]

        public bool IsOrganic { get; set; }
        [Required]
        public bool IsActive { get; set; }
        public Product()
        {
            IsActive = true;
        }

        [Required]
        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Display(Name = "Added")]
        public DateTime Added { get; set; }

        [NotMapped]
        [Display(Name = "Expires")]
        public DateTime ExpirationDate { get; set; }

        public virtual ICollection<OrderProduct> OrderProducts { get; set; }

    }
}
