using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductTracker.Models.Product
{
    public class ProductListItem
    {
        [Display(Name = "Product Id")]
        public int ProductId { get; set; }
        [Display(Name = "Product Name")]
        public string Name { get; set; }
        [Display(Name = "Category Name")]
        public string Category { get; set; }
        public int MSRP { get; set; }
    }
}
