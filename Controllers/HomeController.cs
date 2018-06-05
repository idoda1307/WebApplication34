using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication34.Repositories;

namespace WebApplication34.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            UpdateProductState update = new UpdateProductState();
            update.ChangeProductStateAddedToCart();
            FindAllProductsByState rep = new FindAllProductsByState();
            var products = rep.GetAvailableProducts();
            foreach (var p in products)
            {
                if (Request.Cookies["userName"] != null && Request.Cookies["userName"].Value != null)
                    p.price = p.price * Convert.ToDecimal(0.9);
            }
            return View(products);
        }

        public ActionResult SortByName()
        {
            SortProducts sort = new SortProducts();
            var products = sort.SortByName();
            return View("Index", products);
        }
        public ActionResult SortByDate()
        {
            SortProducts sort = new SortProducts();
            var products = sort.SortByDate();
            return View("Index", products);
        }
    }
}