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
    public class AdminCommunicationsController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult ComunicationsList()
        {
            var values = context.Communications.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult UpdateCommunication(int id)
        {
            var values = context.Communications.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateCommunication(Communication communication)
        {
            var values = context.Communications.Find(communication.CommunicationId);
            values.Address = communication.Address;
            values.Description = communication.Description;
            values.Email = communication.Email;
            values.Phone = communication.Phone;
   
            context.SaveChanges();
            return RedirectToAction("ComunicationsList");
        }
    }
}