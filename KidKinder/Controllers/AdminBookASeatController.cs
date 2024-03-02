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
    public class AdminBookASeatController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult BookASeatList()
        {
            var values = context.BookASeats.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddRezerve()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddRezerve(BookASeat bookASeat)
        {
            context.BookASeats.Add(bookASeat);
            context.SaveChanges();
            return RedirectToAction("BookASeatList");
        }
        [HttpGet]
        public ActionResult UpdateRezerve(int id)
        {
            var values = context.BookASeats.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateRezerve(BookASeat bookASeat)
        {
            var values = context.BookASeats.Find(bookASeat.BookASeatId);
            values.Name = bookASeat.Name;
            values.Email = bookASeat.Email;
         
            context.SaveChanges();
            return RedirectToAction("BookASeatList");
        }
        public ActionResult DeleteRezerve(int id)
        {
            var values = context.BookASeats.Find(id);
            context.BookASeats.Remove(values);
            context.SaveChanges();
            return RedirectToAction("BookASeatList");
        }
    }
}