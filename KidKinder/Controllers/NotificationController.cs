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
    public class NotificationController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult NotificationList()
        {
            var values = context.Notifications.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddNotification()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddNotification(Notification notification)
        {
            context.Notifications.Add(notification);
            context.SaveChanges();
            return RedirectToAction("NotificationList");
        }
        [HttpGet]
        public ActionResult UpdateNotification(int id)
        {
            var values = context.Notifications.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateNotification(Notification notification)
        {
            var values = context.Notifications.Find(notification.NotificationId);
            values.Title = notification.Title;
            values.Description = notification.Description;
            values.ImageUrl = notification.ImageUrl;
            values.NotificationDate = notification.NotificationDate;
   
            context.SaveChanges();
            return RedirectToAction("NotificationList");
        }
        public ActionResult DeleteNotification(int id)
        {
            var values = context.Notifications.Find(id);
            context.Notifications.Remove(values);
            context.SaveChanges();
            return RedirectToAction("NotificationList");
        }
    }
}