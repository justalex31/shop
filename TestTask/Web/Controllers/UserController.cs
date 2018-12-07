using Core.Collection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using Web.Extensions;
using Web.Models;
using Web.Models.OrderViewModel;

namespace Web.Controllers
{
    [Authorize(Roles = "user")]
    public class UserController : Controller
    {
        private UnitOfWork context;

        public UserController() {
            context = new UnitOfWork();
        }

        public ActionResult IndexOrder()
        {
            return View(new OrderIndexViewModel
            {
                Cart = GetCart(),
                ReturnUrl = null
            });
        }

        [HttpGet]
        public ActionResult BuyProduct(Guid id)
        {
            var product = context.Product.Get(id);

            GetCart().AddItem(product, 1);

            return Redirect("/Home/Index");
        }

        [HttpGet]
        public ActionResult RemoveFromCart(Guid id)
        {
            var product = context.Product.Get(id);

            GetCart().RemoveLine(product);

            return Redirect("/Home/Index");
        }

        public Cart GetCart()
        {
            var cart = HttpContext.Session.Get<Cart>("Cart");
            if (cart == null)
            {
                cart = new Cart();

                HttpContext.Session.Set<Cart>("Cart", cart);
            }
            return cart;
        }
    }
}
