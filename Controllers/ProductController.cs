using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication34.Models;
using WebApplication34.Repositories;

namespace WebApplication34.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        [HttpGet]
        public ActionResult GetDetails()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GetDetails(ProductsModel p, HttpPostedFileBase img1, 
            HttpPostedFileBase img2, HttpPostedFileBase img3)
        {
            if (ModelState.IsValid)
            {
                FindUserRepository find = new FindUserRepository();
                Product prod = new Product()
                {
                    ProductID=p.ID,
                    Date=DateTime.Now,
                    State=(int)p.status,
                    Title = p.title,
                    ShortDescription = p.shortDescription,
                    LongDescription = p.longDescription,
                    Price = p.price
                };
                if (Request.Cookies["userName"].Value != null)
                {
                    prod.OwnerID = find.FindUserId(Request.Cookies["userName"].Value);
                    p.ownerID= find.FindUserId(Request.Cookies["userName"].Value);
                }
                if (img1 != null || img2 != null || img3 != null)
                {
                    string fileName1, fileName2, fileName3;
                    if (img1 != null)
                    {
                        fileName1 = Path.GetFileName(img1.FileName);
                        string fullPath = Path.Combine(Server.MapPath("~/uploads"), fileName1);
                        img1.SaveAs(fullPath);
                        p.image1 = ($"/uploads/" + fileName1);
                        prod.Picture1 = p.image1;
                    }
                    if (img2 != null)
                    {
                        fileName2 = Path.GetFileName(img2.FileName);
                        string fullPath = Path.Combine(Server.MapPath("~/uploads"), fileName2);
                        img2.SaveAs(fullPath);
                        p.image2 = ($"/uploads/" + fileName2);
                        prod.Picture2 = p.image2;
                    }
                    if (img3 != null)
                    {
                        fileName3 = Path.GetFileName(img3.FileName);
                        string fullPath = Path.Combine(Server.MapPath("~/uploads"), fileName3);
                        img3.SaveAs(fullPath);
                        p.image3 = ($"/uploads/" + fileName3);
                        prod.Picture3 = p.image3;
                    }
                }
                AddToDBRepository add = new AddToDBRepository();
                add.AddProduct(prod);
                return Content("Youre product has been added to our site"+"<br>"+ "<a href=http://localhost:64245/Home/Index> Home Page</a>");
            }
            else
            {
                return View();
            }
        }
    }
}