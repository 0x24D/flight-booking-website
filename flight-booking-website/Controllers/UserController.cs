using flight_booking_website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace flight_booking_website.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LogIn(UserModel user)
        {
            if (ModelState.IsValid)
            {
                if (user.IsValid(user.Email, user.Password))
                {
                    FormsAuthentication.SetAuthCookie(user.Email, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Login Data is Incorrect!");
                }
            }
            return View(user);
        }
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registration(UserModel user)
        {

            if (ModelState.IsValid)
            {
                using (var db = new FlightsBookingsDBEntities())
                {
                    var crypto = new SimpleCrypto.PBKDF2();
                    var encrypPass = crypto.Compute(user.Password);
                    var sysUser = db.UsersTbls.Create();

                    sysUser.Email = user.Email;
                    sysUser.Password = encrypPass;
                    sysUser.Password_Salt = crypto.Salt;
                    db.UsersTbls.Add(sysUser);

                    db.SaveChanges();

                    return RedirectToAction("Index", "Home");

                }
            }
            else
            {
                ModelState.AddModelError("", "Login Data is Incorrect!");
            }
            return View();
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}
