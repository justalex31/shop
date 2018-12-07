using Core.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using Web.Models;
using Web.Models.OrderViewModel;
using Web.Models.ProductViewModel;

namespace Web.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private UnitOfWork context;

        public AdminController() => context = new UnitOfWork();

        [HttpGet]
        public ActionResult IndexCatalog(string search)
        {
            var list = context.Catalog.GetAll();

            if (!string.IsNullOrWhiteSpace(search))
                list = list.Where(x => x.Name.Contains(search));

            return View(list);
        }

        [HttpGet]
        public ActionResult CreateCatalog() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCatalog(Catalog catalog)
        {
            if (ModelState.IsValid)
            {

                var _catalog = new Catalog { Name = catalog.Name };

                context.Catalog.Add(_catalog);
                context.Save();

                return RedirectToAction(nameof(IndexCatalog));
            }

            return View(catalog);
        }

        [HttpGet]
        public ActionResult EditProduct(Guid id)
        {
            
            var product = context.Product.GetWithCatalog(id);

            var model = new CreateProductViewModel
            {
                ID = product.ID,
                Name = product.Name,
                Price = product.Price,
                CatalogID = product.CatalogID
            };

            var catalogs = new SelectList(context.Catalog.GetAll(), "ID", "Name", model.CatalogID);
            ViewBag.Catalogs = catalogs;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProduct(CreateProductViewModel model)
        {
            if (ModelState.IsValid) {

                var product = context.Product.Get(model.ID);
                product.Name = model.Name;
                product.Price = model.Price;
                product.CatalogID = model.CatalogID;

                context.Context.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.Save();

                return Redirect("/Home/Index");
            }
            var catalogs = new SelectList(context.Catalog.GetAll(), "ID", "Name", model.CatalogID);
            ViewBag.Catalogs = catalogs;

            return View(model);
        }

        [HttpGet]
        public ActionResult EditCatalog(Guid id)
        {
            var catalog = context.Catalog.Get(id);

            return View(catalog);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCatalog(Guid id, Catalog model)
        {
            if (ModelState.IsValid)
            {
                var catalog = context.Catalog.Get(id);
                catalog.Name = model.Name;
                context.Save();

                return RedirectToAction(nameof(IndexCatalog));
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult DeleteCatalog(Guid id)
        {
            if (id != null)
            {
                var catalog = context.Catalog.Get(id);

                if (catalog != null)
                    context.Catalog.Delete(catalog);
                context.Save();
            }

            return RedirectToAction(nameof(IndexCatalog));
        }

        [HttpGet]
        public ActionResult DeleteProduct(Guid id)
        {
            if (id != null)
            {
                var product = context.Product.Get(id);

                if (product != null)
                    context.Product.Delete(product);
                context.Save();
            }

            return Redirect("/Home/Index");
        }

        [HttpGet]
        public ActionResult CreateProduct()
        {
            var catalog = new SelectList(context.Catalog.GetAll(), "ID", "Name");
            ViewBag.Catalogs = catalog;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateProduct(CreateProductViewModel model)
        {
            if (ModelState.IsValid)
            {

                var product = new Product
                {
                    Name = model.Name,
                    Price = model.Price,
                    CatalogID = model.CatalogID
                };

                context.Product.Add(product);
                context.Save();

                return Redirect("/Home/Index");
            }
            return View(model);
        }

        public ActionResult IndexOrder()
        {
            var orders = context.Order.GetAllInclude();

            var model = new List<IndexAdminOrderViewModel>();
            
            return View()
        }
    }
}