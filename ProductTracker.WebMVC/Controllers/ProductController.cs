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
        public ProductService CreateProductService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ProductService(userId);
            return service;
        }
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ProductService(userId);
            var model = service.GetProducts();
            return View(model);

        }
        public ActionResult Details(int id)
        {
            var svc = CreateProductService();
            var model = svc.GetProductById(id);

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
            ModelState.AddModelError("", "Product could not be created.");

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var svc = CreateProductService();
            var detail = svc.GetProductById(id);
            var model =
                new ProductEdit
                {
                    ProductId = detail.ProductId,
                    Name = detail.Name,
                    Category = detail.Category,
                    MSRP = detail.MSRP
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProductEdit model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (model.ProductId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateProductService();

            if (service.UpdateProduct(model))
            {
                TempData["SaveResult"] = "Your product was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your product could not be updated.");
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateProductService();
            var model = svc.GetProductById(id);

            return View(model);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteProduct(int id)
        {
            var service = CreateProductService();

            service.DeleteProduct(id);

            TempData["SaveResult"] = "The product was deleted";

            return RedirectToAction("Index");
        }

    }
}