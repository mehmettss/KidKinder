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
    public class AdminGaleryController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult GaleryList()
        {
            var values = context.Galleries.ToList();
            return View(values);
        }
        public ActionResult CreateGallery()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateGallery(Gallery gallery)
        {
            gallery.ImageStatus = false;
            context.Galleries.Add(gallery);
            context.SaveChanges();
            return RedirectToAction("GaleryList");
        }
        public ActionResult ImageChangeStatusTrue(int id)
        {
            var value = context.Galleries.Find(id);
            value.ImageStatus = true;
            context.SaveChanges();
            return RedirectToAction("GaleryList");
        }
        public ActionResult ImageChangeStatusFalse(int id)
        {
            var value = context.Galleries.Find(id);
            value.ImageStatus = false;
            context.SaveChanges();
            return RedirectToAction("GaleryList");
        }
        [HttpGet]
        public ActionResult UpdateImage(int id)
        {
            var value = context.Galleries.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateImage(Gallery gallery)
        {
            var value = context.Galleries.Find(gallery.GalleryId);
            value.ImageUrl = gallery.ImageUrl;
        
            context.SaveChanges();
            return RedirectToAction("GaleryList");
        }

    }
}