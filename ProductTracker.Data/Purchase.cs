using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductTracker.Data
{
    public class Purchase
    {
        [Key]
        [Display(Name = "Purchase Id")]
        public int PurchaseId { get; set; }
        [Required]
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        [Required]
        public string ItemName { get; set; }
        [Required]
        [Display(Name = "Purchase Price")]
        public int PurchasePrice { get; set; }
        [Required]
        [Display(Name = "Store")]
        public string StoreBoughtFrom { get; set; } 
        [Required]
        public string Condition { get; set; }
        [Required]
        public DateTime PurchaseDate { get; set; }
        public Guid OwnerID { get; set; }
        public virtual List<ProductTracker.Data.Product> Products { get; set; }
    }
}
