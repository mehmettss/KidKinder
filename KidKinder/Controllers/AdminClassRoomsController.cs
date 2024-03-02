﻿using KidKinder.Context;
using KidKinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{
    public class AdminClassRoomsController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult ClassRoomsList()
        {
            var values = context.ClassRooms.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddClass()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddClass(ClassRoom classRoom)
        {
            context.ClassRooms.Add(classRoom);
            context.SaveChanges();
            return RedirectToAction("ClassRoomsList");
        }
        [HttpGet]
        public ActionResult UpdateClass(int id)
        {
            var values = context.ClassRooms.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateClass(ClassRoom classRoom)
        {
            var values = context.ClassRooms.Find(classRoom.ClassRoomId);
            values.Title = classRoom.Title;
            values.Description=classRoom.Description;
            values.AgeofKids = classRoom.AgeofKids;
            values.TotalSeat = classRoom.TotalSeat;
            values.ClassTime = classRoom.ClassTime;
            values.Price = classRoom.Price;
            values.ImageUrl = classRoom.ImageUrl;
            context.SaveChanges();
            return RedirectToAction("ClassRoomsList");
        }
        public ActionResult DeleteClassRooms(int id)
        {
            var values = context.ClassRooms.Find(id);
            context.ClassRooms.Remove(values);
            context.SaveChanges();
            return RedirectToAction("ClassRoomsList");
        }
    }
}