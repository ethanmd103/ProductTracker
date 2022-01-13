using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductTracker.Models.Purchase
{
    public class PurchaseEdit
    {
        [Required]
        [Display(Name = "Purchase Id")]
        public int PurchaseId { get; set; }
        [Display(Name = "Purchase Name")]
        public string PurchaseName { get; set; }
        [Display(Name = "Purchase Price")]
        public int PurchasePrice { get; set; }
        public string StoreBoughtFrom { get; set; }
        public string Condition { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}
