using ProductTracker.Models.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductTracker.Models.Purchase
{
    public class PurchaseCreate
    {
        [Display(Name = "Item Name")]
        [Required]
        public string ItemName { get; set; }
        [Display(Name = "Purchase Price")]
        [Required]
        public int PurchasePrice { get; set; }
        [Display(Name = "Store")]
        [Required]
        public string StoreBoughtFrom { get; set; }
        [Required]
        public string Condition { get; set; }
        [Required]
        public DateTime PurchaseDate { get; set; }
        public virtual List<ProductTracker.Data.Product> Products { get; set; }
        [Required]
        public int ProductId { get; set; }
    }
}
