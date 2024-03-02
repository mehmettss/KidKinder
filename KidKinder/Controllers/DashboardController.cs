using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KidKinder.Context;
using KidKinder.Entities;
using KidKinder.Models;

namespace KidKinder.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult Index()
        {
            ViewBag.branchIdByResimCizme=context.Branches.Where(x=>x.BranchId==context.Branches.Where(z=>z.Name== "Resim Cizim").Select(y=>y.BranchId).FirstOrDefault()).Count();
            ViewBag.AvgPrice=context.ClassRooms.Average(x=>x.Price).ToString("0.00");
            ViewBag.TotalAdmin = context.Admins.Count();
            ViewBag.TotalMessage = context.Contacts.Count();
            ViewBag.RezervasyonCount = context.BookASeats.Count();
            ViewBag.ClassCount = context.ClassRooms.Count();
            ViewBag.BranchCount = context.Branches.Count();
            ViewBag.TeacherCount = context.Teachers.Count();
            ViewBag.HighestPricedClassTitle = context.ClassRooms.OrderByDescending(c => c.Price).FirstOrDefault()?.Title;
            ViewBag.LowestPricedClassTitle = context.ClassRooms.OrderBy(y => y.Price).FirstOrDefault()?.Title;
         
            return View();
        }
        public PartialViewResult _DashboardTestimonialPartial()
        {
            var values = context.Testimonials.ToList();
            return PartialView(values);
        }
        public PartialViewResult _DashboardTeacherPartial()
        {
            List<SelectListItem> listItems = (from x in context.Branches.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Name,
                                               Value = x.BranchId.ToString()
                                           }).ToList();
            ViewBag.v = listItems;
            var values = context.Teachers.ToList();
            return PartialView(values);
        }
        public ActionResult _GrafikPartial()
        {
            return Json(classPrice(), JsonRequestBehavior.AllowGet);
        }

        public List<GrafikModel> classPrice()
        {
            List<GrafikModel> cs = new List<GrafikModel>();
            cs = context.ClassRooms.Select(x => new GrafikModel
            {
                Sınıf =x.Title,
                Fiyat = x.Price,
            }).ToList();
            return cs;
        }
    }
}