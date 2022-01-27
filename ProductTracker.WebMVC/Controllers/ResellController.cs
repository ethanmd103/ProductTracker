using Microsoft.AspNet.Identity;
using ProductTracker.Models.Resell;
using ProductTracker.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductTracker.WebMVC.Controllers
{
    public class ResellController : Controller
       
    {
        [Authorize]
        // GET: Resell
        public ResellService CreateResellService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ResellService(userId);
            return service;
        }
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ResellService(userId);
            var model = service.GetResells();
            return View(model);
        }
        public ActionResult Details(int id)
        {
            var svc = CreateResellService();
            var model = svc.GetResellById(id);

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
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var svc = CreateResellService();

            if (svc.CreateResell(model))
            {
                TempData["SaveResult"] = "Your resale was created.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Resale could not be created");

            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateResellService();
            var detail = service.GetResellById(id);
            var model =
                new ResellEdit
                {
                    SalePrice = detail.SalePrice,
                    Customer = detail.Customer,
                    Location = detail.Location,
                    ResellDate = detail.ResellDate,
                    ProductId = detail.ProductId
                    
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ResellEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ResellId != id)
            {
                ModelState.AddModelError("", "Id's don't match");
                return View(model);
            }

            var service = CreateResellService();
            if (service.UpdateResell(model))
            {
                TempData["SaveResult"] = "Your resale was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The resale could not be updated.");
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateResellService();
            var model = svc.GetResellById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteResell(int id)
        {
            var service = CreateResellService();

            service.DeleteResell(id);

            TempData["SaveResult"] = "The resale was deleted";

            return RedirectToAction("Index");
        }

    }
}