using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductTracker.Models.Resell
{
    public class ResellCreate
    {
        [Display(Name = "Resale Price")]
        [Required]
        public int SalePrice { get; set; }
        [Required]
        public string Customer { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public DateTime ResellDate { get; set; }
        public virtual List<ProductTracker.Data.Product> Products { get; set; }
        [Required]
        public int ProductId { get; set; }
    }
}
