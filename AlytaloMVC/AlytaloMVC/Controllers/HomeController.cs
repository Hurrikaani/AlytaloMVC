using AlytaloMVC.Models;
using AlytaloMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlytaloMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Login(UserDataViewModel us)
        {
            if (ModelState.IsValid)
            {
                älytalodbEntities entities = new älytalodbEntities();
                {
                    var log = entities.Users.Where(a => a.UserName.Equals(us.UserName) && a.Password.Equals(us.Password)).FirstOrDefault();
                    if (log != null)
                    {
                        Session["username"] = log.UserName;
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        Response.Write("<script> alert('Väärä salasana')</script>");
                    }
                }
            }
            return View();
        }
        public ActionResult UsersHome()
        {
            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login", "Home");

        }

        public ActionResult Register()
        {
            UserDataViewModel Log = new UserDataViewModel();
            return View(Log);

        }
        [HttpPost]
        public ActionResult Register(UserDataViewModel LogEnt)
        {

            if (ModelState.IsValid)
            {
                älytalodbEntities Log = new älytalodbEntities();

                Users us = new Users();
                us.UserName = LogEnt.UserName;
                us.Password = LogEnt.Password;
                Log.Users.Add(us);
                Log.SaveChanges();
                ViewBag.Success = "Your username is: " + LogEnt.UserName + " And password: " + LogEnt.Password;
            }

            return View(LogEnt);
        }
    }
}