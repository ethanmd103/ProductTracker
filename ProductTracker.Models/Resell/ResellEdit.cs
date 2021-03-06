using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductTracker.Models.Resell
{
    public class ResellEdit
    {
        [Display(Name = "Resell Id")]
        public int ResellId { get; set; }
        [Display(Name = "Sale Price")]
        public int SalePrice { get; set; }
        public string Customer { get; set; }
        public string Location { get; set; }
        public DateTime ResellDate { get; set; }
        public int ProductId { get; set; }
    }
}
