using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication34.Models;
using WebApplication34.Repositories;

namespace WebApplication34.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        [HttpGet]
        public ActionResult GetDetails()
        {
            if (Request.Cookies["userName"] != null && Request.Cookies["userName"].Value != null)
            {
                FindUserRepository get = new FindUserRepository();
                UsersModel use = get.FindUserModelByUserName(Request.Cookies["userName"].Value);
                return View(use);
            }
            else return View();
        }
        [HttpPost]
        public ActionResult GetDetails(UsersModel user)
        {
            if (ModelState.IsValid)
            {
                AddToDBRepository add = new AddToDBRepository();
                add.AddUser(user);
                HttpCookie cookie = new HttpCookie("userName");
                cookie.Value = user.userName.ToString();
                Response.Cookies.Add(cookie);
                FindUserRepository get = new FindUserRepository();
                UsersModel use = get.FindUserModelByUserName(Request.Cookies["userName"].Value);
                return View(use);
            }
            else
            {
                return View();
            }
        }
    }
}