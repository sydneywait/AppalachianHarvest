using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppalachianHarvest.Models.ViewModels
{
    public class CreateEditProductViewModel
    {
        public Product Product { get; set; }
        public SelectList Producers { get; set; }
        public SelectList Shelves { get; set; }
        public SelectList ProductTypes { get; set; }



    }
}
