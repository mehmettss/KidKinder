﻿using KidKinder.Context;
using KidKinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{
    [Authorize]
    public class AdminServiceController : Controller
    {
        KidKinderContext context = new KidKinderContext();

        public ActionResult ServiceList()
        {
            var values = context.Services.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddService()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddService(Service service)
        {
            context.Services.Add(service);
            context.SaveChanges();
            return RedirectToAction("ServiceList");
        }
        [HttpGet]
        public ActionResult UpdateService(int id)
        {
            var values = context.Services.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateService(Service service)
        {
            var values = context.Services.Find(service.ServiceId);
            values.Title = service.Title;
            values.Description = service.Description;
      
            values.IconUrl = service.IconUrl;
            context.SaveChanges();
            return RedirectToAction("ServiceList");
        }
        public ActionResult DeleteService(int id)
        {
            var values = context.Services.Find(id);
            context.Services.Remove(values);
            context.SaveChanges();
            return RedirectToAction("ServiceList");
        }
    }
}