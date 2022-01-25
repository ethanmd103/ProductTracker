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
        [Display(Name = "Product Name")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "Category Name")]
        [Required]
        public string Category { get; set; }
        [Required]
        public int MSRP { get; set; }
    }
}
