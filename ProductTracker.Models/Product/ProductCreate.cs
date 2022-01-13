using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductTracker.Models.Product
{
    public class ProductCreate
    {
        [Required]
        [Display(Name = "Product Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Category Name")]
        public string Category { get; set; }
        [Required]
        public int MSRP { get; set; }
    }
}
