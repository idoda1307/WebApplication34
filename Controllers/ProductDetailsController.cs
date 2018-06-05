using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication34.Models;
using WebApplication34.Repositories;

namespace WebApplication34.Controllers
{
    public class ProductDetailsController : Controller
    {
        // GET: ProductDetails
        public ActionResult MoreDetails(long id)
        {
            FindProductRepository f = new FindProductRepository();
            FindUserRepository find = new FindUserRepository();
            ProductsModel pr = f.FindProductModelByID(id);
            pr.owner = find.FindUserModelByID(pr.ownerID);
            if (Request.Cookies["userName"] != null && Request.Cookies["userName"].Value != null)
            {
                pr.price = pr.price * Convert.ToDecimal(0.9);
            }
            return View(pr);
           
        }
    }
}