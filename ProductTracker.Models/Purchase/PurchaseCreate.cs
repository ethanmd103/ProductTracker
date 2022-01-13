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
        [Required]
        [Display(Name = "Purchase Name")]
        public string PurchaseName { get; set; }
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
    }
}
