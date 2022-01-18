using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Display(Name = "Sale Price")]
        public int SalePrice { get; set; }  
        [Required]
        public string Customer { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public DateTime ResellDate { get; set; }  
        public Guid OwnerID { get; set; }
        public virtual List<Product> Products { get; set; }

    }
}
