using Microsoft.AspNet.Identity;
using ProductTracker.Models.Purchase;
using ProductTracker.Services;
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
        public PurchaseService CreatePurchaseService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PurchaseService(userId);
            return service;
        }
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PurchaseService(userId);
            var model = service.GetPurchases();

            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PurchaseCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var svc = CreatePurchaseService();

            if (svc.CreatePurchase(model))
            {
                TempData["SaveResult"] = "Your Purchase was created.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Purchase could not be created.");

            return View(model);
        }
        public ActionResult Details(int id)
        {
            var svc = CreatePurchaseService();
            var model = svc.GetPurchaseById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreatePurchaseService();
            var detail = service.GetPurchaseById(id);
            var model = new PurchaseEdit
            {
                PurchaseId = detail.PurchaseId,
                ItemName = detail.ItemName,
                PurchasePrice = detail.PurchasePrice,
                StoreBoughtFrom = detail.StoreBoughtFrom,
                Condition = detail.Condition,
                PurchaseDate = detail.PurchaseDate
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PurchaseEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.PurchaseId != id)
            {
                ModelState.AddModelError("", "Ids don't match!");
                return View(model);
            }
            var service = CreatePurchaseService();

            if (service.UpdatePurchase(model))
            {
                TempData["SaveResult"] = "The purchase was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The purchase could not be updated.");
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreatePurchaseService();
            var model = svc.GetPurchaseById(id);

            return View(model);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePurchase(int id)
        {
            var service = CreatePurchaseService();

            service.DeletePurchase(id);

            TempData["SaveResult"] = "Purchase was deleted!";

            return RedirectToAction("Index");

        }



    }
}