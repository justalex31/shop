using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Web.Helper;
using Web.Models;
using Web.Models.ProductViewModel;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private UnitOfWork context;
        private FilterData filter;

        public HomeController() {
            filter = new FilterData();
            context = new UnitOfWork();
        }


        public IActionResult Index(double startPriceAt = 0, double endPriceAt = double.MaxValue, string sortBy = "SortByCostFrom0", double startRatingAt = 0, double endRatingAt = 5)
        {
            var list = context.Product.GetAllWithIncludes();

            var _list = new List<IndexProductViewModel>();

            foreach (var obj in list)
            {
                var r = obj.Rates.Select(x => x.Rating).ToArray();
                double ave = 0;

                if (r != null)
                    ave = MathFunc.Aver(r);

                _list.Add(new IndexProductViewModel
                {
                    ID = obj.ID,
                    Name = obj.Name,
                    Price = obj.Price,
                    NameCatalog = obj.Catalog.Name,
                    Rating = ave
                });
            }

            ViewBag.Sort = new SelectList(new List<SelectListItem>
            {
                new SelectListItem { Selected =  true, Text = "SortByCostFrom0", Value = "1" },
                new SelectListItem { Selected = false, Text = "SortByCostTo0", Value = "2" },
                new SelectListItem { Selected = false, Text = "RatingFrom0", Value = "3" },
                new SelectListItem { Selected = false, Text = "RaringTo0", Value = "4" }
            }, "Value", "Text");

            _list = filter.Filter(_list, startPriceAt, endPriceAt, startRatingAt, endRatingAt);

            switch(sortBy)
            {
                case "1":
                    _list = _list.OrderBy(x => x.Price).ToList();
                    break;
                case "2":
                    _list = _list.OrderByDescending(x => x.Price).ToList();
                    break;
                case "3":
                    _list = _list.OrderBy(x => x.Rating).ToList();
                    break;
                case "4":
                    _list = _list.OrderByDescending(x => x.Rating).ToList();
                    break;
            }

            return View(_list);
        }
    }
}
