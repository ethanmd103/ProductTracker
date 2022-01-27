using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductTracker.Data
{
    public class Resell
    {
        [Key]
        [Display(Name = "Resell Id")]
        public int ResellId { get; set; }
        [Required]
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        [Required]
        [Display(Name = "Sale Price")]
        public int SalePrice { get; set; }  
        [Required]
        public string Customer { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public DateTime ResellDate { get; set; }  
        public Guid OwnerID { get; set; }
        public virtual List<ProductTracker.Data.Product> Products { get; set; }

    }
}
