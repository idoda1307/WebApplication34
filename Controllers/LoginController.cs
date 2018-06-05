using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication34.Models;
using WebApplication34.Repositories;

namespace WebApplication34.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserLogin user)
        {
            if (ModelState.IsValid)
            {
                LoginRepository log = new LoginRepository();
                if (log.FindUser(user.userName, user.password) != null)
                {
                    HttpCookie cookie = new HttpCookie("userName");
                    cookie.Value = user.userName.ToString();
                    Response.Cookies.Add(cookie);
                    return View(user);
                }
            }
            return View();
        }
        public ActionResult Logout()
        {
            if (Request.Cookies["userName"] != null)
            {
                HttpCookie myCookie = new HttpCookie("userName");
                myCookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(myCookie);
            }
            return RedirectToAction("Index", controllerName: "Home");
        }
    }
}