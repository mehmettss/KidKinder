using KidKinder.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{
    [Authorize]
    public class AdminContactController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult ContactList()
        {
            var values = context.Contacts.ToList();
            return View(values);
        }
        public ActionResult DeleteContact(int id)
        {
            var values = context.Contacts.Find(id);
            context.Contacts.Remove(values);
            context.SaveChanges();
            return RedirectToAction("ContactList");
        }
    }
}