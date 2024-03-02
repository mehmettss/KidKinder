using KidKinder.Context;
using KidKinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{
    [Authorize]
    public class AdminProfileController : Controller
    {
        KidKinderContext context = new KidKinderContext();

        public ActionResult Index()
        {
            var values = context.Admins.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddUser(Admin admin)
        {
            context.Admins.Add(admin);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateUser(int id)
        {
            var values = context.Admins.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateUser(Admin admin)
        {
            var values = context.Admins.Find(admin.AdminId);
            values.Username = admin.Username;
            values.Password = admin.Password;
  
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}