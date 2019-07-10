using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppalachianHarvest.Models.SubModels
{
    public class ProductReport
    {
        public Product Product { get; set; }
        
        public int Sold { get; set; }
        public int Expired { get; set; }

    }
}
