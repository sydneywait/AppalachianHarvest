using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AppalachianHarvest.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Order Date")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime OrderDate { get; set; }
        [Required]
        [Display(Name ="Customer")]
        public string CustomerId { get; set; }
        [Display(Name = "Customer")]
        public ApplicationUser Customer { get; set; }

        [Required]
        [Display(Name = "Scheduled Pick-up")]
        public DateTime PickupDate { get; set; }

        public ICollection<Product> Products { get; set; }

    }
}
