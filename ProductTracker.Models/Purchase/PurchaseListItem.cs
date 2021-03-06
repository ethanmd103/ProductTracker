using ProductTracker.Models.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductTracker.Models.Purchase
{
    public class PurchaseListItem
    {
        [Display(Name = "Purchase Id")]
        public int PurchaseId { get; set; }
        [Display(Name = "Item Name")]
        public string ItemName { get; set; }
        [Display(Name = "Purchase Price")]
        public int PurchasePrice { get; set; }
        public string StoreBoughtFrom { get; set; }
        public string Condition { get; set; }
        public DateTime PurchaseDate { get; set; }
        public virtual List<ProductTracker.Data.Product> Products { get; set; }
        public int ProductId { get; set; }
    }
}
