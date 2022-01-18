using ProductTracker.Models.Resell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductTracker.WebMVC.Controllers
{
    public class ResellController : Controller
    {
        // GET: Resell
        public ActionResult Index()
        {
            var model = new ResellListItem[0];
            return View(model); 
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ResellCreate model)
        {
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}