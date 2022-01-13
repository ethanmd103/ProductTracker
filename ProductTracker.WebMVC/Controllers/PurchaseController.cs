using ProductTracker.Models.Purchase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductTracker.WebMVC.Controllers
{
    public class PurchaseController : Controller
    {
        // GET: Purchase
        public ActionResult Index()
        {
            var model = new PurchaseListItem[0];
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
    }
}