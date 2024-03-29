﻿using AppalachianHarvest.Models.SubModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppalachianHarvest.Models.ViewModels
{
    public class ProducerReportViewModel
    {
        [Display(Name = "Select a Start Date")]
        public DateTime StartDate { get; set; }
        [Display(Name = "Select an End Date")]
        public DateTime EndDate { get; set; }
        [Display(Name = "Select a Producer")]
        public Producer selectedProducer { get; set; }
        public SelectList Producers { get; set; }
        public ProductType selectedProductType { get; set; }

        public SelectList ProductTypes { get; set; }

        public double TotalSales { get; set; }
        public double TotalLosses { get; set; }
        public Product MostPopular { get; set; }
        public Product LeastPopular { get; set; }

        public List<ProductReport> soldProducts { get; set; } = new List<ProductReport>();
        public List<Product> expiredProducts { get; set; }
        public ICollection<Order> Orders { get; set; }


    }
}
