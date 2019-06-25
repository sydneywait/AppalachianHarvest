﻿using System;
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
        public int ProductId { get; set; }
        [Required]
        [StringLength(55, ErrorMessage = "Please shorten the product name to 55 characters")]
        public string Name { get; set; }
        [Required]
        public int ProducerId { get; set; }
        public Producer Producer { get; set; }

        [Required(ErrorMessage = "Please Select a Product Category")]
        [Display(Name = "Product Category")]
        public int ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }
        [Required]
        public int ShelfId { get; set; }
        public Shelf Shelf { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double Price { get; set; }
        [Display(Name = "Image")]

        public byte[] Image { get; set; }
        [Required]
        public bool IsOrganic { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Display(Name = "Date Added")]
        public DateTime Added { get; set; }

    }
}
