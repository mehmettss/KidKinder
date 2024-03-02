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
    public class AdminAboutController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult AdminAboutList()
        {
            var values = context.Abouts.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult UpdateAboutList(int id)
        {
            var values = context.Abouts.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateAboutList(About about)
        {
            var values = context.Abouts.Find(about.AboutId);
            values.Title = about.Title;
            values.Description = about.Description;
            values.AboutBigImageUrl = about.AboutBigImageUrl;
            values.Header = about.Header;
            values.SmallImageUrl = about.SmallImageUrl;
   
            context.SaveChanges();
            return RedirectToAction("AdminAboutList");
        }
    }
}