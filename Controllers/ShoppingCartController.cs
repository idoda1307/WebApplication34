using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using System.Web;
using System.Web.Mvc;
using WebApplication34.Infrastructure.Filters;
using WebApplication34.Models;
using WebApplication34.Repositories;

namespace WebApplication34.Controllers
{
    public class ShoppingCartController : Controller
    {
        public ActionResult AddToCart(long ID)
        {
            FindAllProductsByState product = new FindAllProductsByState();
            UpdateProductState update = new UpdateProductState();
            foreach (var p in product.GetAvailableProducts())
            {
                if (p.ID == ID)
                {
                    if (Request.Cookies["userName"] != null && Request.Cookies["userName"].Value != null)
                    {
                        FindUserRepository find = new FindUserRepository();
                        p.userID = find.FindUserId(Request.Cookies["userName"].Value);
                        update.ChangeProductStateToCart(ID, p.userID);
                        SetTimer(p);
                    }
                    else
                    {
                        if ( Session["cart"] ==null)
                        {
                            List<ProductsModel> list = new List<ProductsModel>();
                            list.Add(p);
                            Session["cart"] = list;
                        }
                        else
                        {
                            List<ProductsModel> list = (List<ProductsModel>)Session["cart"];
                            list.Add(p);
                            Session["cart"] = list;
                        }
                        update.ChangeStateToCartGuest(p.ID);
                    }
                }
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public ActionResult RemoveProduct(string prodId)
        {
            if (Request.Cookies["userName"] != null && Request.Cookies["userName"].Value != null)
            {
                FindProductRepository find = new FindProductRepository();
                ProductsModel p = find.FindProductModelByID(Convert.ToInt64(prodId));
                if (p != null)
                {
                    UpdateProductState update = new UpdateProductState();
                    update.ChangeProductStateToUploaded(p.ID);
                }
            }
            else
            {
                var list = (List<ProductsModel>)Session["cart"];
                ProductsModel prod = list.Where(x => x.ID == Convert.ToInt64(prodId)).SingleOrDefault();
                Session["cart"] = list.Where(x => x.ID != Convert.ToInt64(prodId)).ToList();
                UpdateProductState update = new UpdateProductState();
                if(prod!=null)
                   update.ChangeProductStateToUploaded(prod.ID);
            }
            return View("Cart");
        }
        
        public ActionResult Cart()
        {
            if (Request.Cookies["userName"] != null && Request.Cookies["userName"].Value != null)
                return UserExist();
            else
            {
                return UserNotExist();
            }
        }
        public ActionResult UserExist()
        {
            FindUserRepository find = new FindUserRepository();
            long id = find.FindUserId(Request.Cookies["userName"].Value);
            AddToCartRepository add = new AddToCartRepository();
            List<ProductsModel> list = add.ProductsInCart(id).ToList();
            foreach(var product in list)
            {
                product.price = product.price * Convert.ToDecimal(0.9);
            }
            return View("Cart",list);
        }
        [SessionExpireFilter]
        public ActionResult UserNotExist()
        {
            List<ProductsModel> sessionList = (List<ProductsModel>)Session["cart"];
            return View("Cart",sessionList);
        }
        Timer timer = new Timer(1200000);
        public void SetTimer(ProductsModel p)
        {
            timer.Elapsed += Timer_Elapsed;
            timer.Enabled = true;
            timer.Start();
        }
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            UpdateProductState update = new UpdateProductState();
            update.ChangeProductStateToAvailable();
        }
        public ActionResult BuyAllProducts()
        {
            UpdateProductState update = new UpdateProductState();
            FindUserRepository find = new FindUserRepository();
            if (Request.Cookies["userName"] != null && Request.Cookies["userName"].Value != null)
            {
                long userId = find.FindUserId(Request.Cookies["userName"].Value);
                update.ChangeProductStateToBoughtUser(userId);
            }
            else
            {
                foreach(var item in (List<ProductsModel>)Session["cart"])
                {
                    update.ChangeProductStateToBoughtGuest(item.ID);
                    var list = (List<ProductsModel>)Session["cart"];
                    Session["cart"] = list.Where(x => x.ID != item.ID).ToList();
                }
            }
            return RedirectToAction("Index","Home");
        }
    }
}