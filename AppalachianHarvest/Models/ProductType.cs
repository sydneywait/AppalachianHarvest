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
        public string Description { get; set; }
        [Required]
        public TimeSpan ExpirationTime { get; set; }
    }
}
