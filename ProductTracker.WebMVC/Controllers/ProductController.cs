using Microsoft.AspNet.Identity;
using ProductTracker.Models.Product;
using ProductTracker.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace ProductTracker.WebMVC.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ProductService(userId);
            var model = service.GetProducts();
            return View(model);

        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var svc = CreateProductService();

            if (svc.CreateProduct(model))
            {
                TempData["SaveResult"] = "Your Product was created.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "ClassRoom could not be created.");

            return View(model);

            ProductService CreateProductService()
            {
                var userId = Guid.Parse(User.Identity.GetUserId());
                var service = new ProductService(userId);
                return service;
            }
        }
    }
}