using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppalachianHarvest.Models
{
    public class ProductType
    {
        [Key]
        public int ProductTypeId { get; set; }
        [Required]
        [Display(Name = "Product Type")]

        public string Description { get; set; }
        [Required]
        // stored as the number of days in sql.  Need to convert to Timespan when working with it
        public int? TimeToExpire { get; set; }
    }
}
