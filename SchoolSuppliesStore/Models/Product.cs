using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolSuppliesStore.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        [Required]
        public string Category { get; set; } // e.g. Notebooks, Pens, Bags
    }
}
