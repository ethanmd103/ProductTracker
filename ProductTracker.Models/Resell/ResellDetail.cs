using ProductTracker.Models.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductTracker.Models.Resell
{
    public class ResellDetail
    {
        [Display(Name = "Resell Id")]
        public int ResellId { get; set; }
        [Required]
        [Display(Name = "Sale Price")]
        public int SalePrice { get; set; }
        [Required]
        public string Customer { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public DateTime ResellDate { get; set; }
        public virtual List<ProductListItem> Products { get; set; }
    }
}
