using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductTracker.Data
{
    public class Product
    {
        [Key]
        [Display(Name = "Product Id")]
        public int ProductID { get; set; }
        [Required]
        [Display(Name = "Product Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Category Name")]
        public string Category { get; set; }
        [Required]
        public int MSRP { get; set; }
        public Guid OwnerID { get; set; }
        public virtual List<Purchase> Purchases { get; set; }
        public virtual List<Resell> Resells { get; set; }
        

    }
}
