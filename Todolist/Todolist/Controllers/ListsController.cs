using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Todolist.Models;


namespace Todolist.Controllers
{
    public class ListsController : Controller
    {
        private readonly TDLEntities _db = new TDLEntities();
        //
        // GET: /Lists/
        [HttpGet]
        public ActionResult Index(Int32 id)
        {
            ViewBag.Username = _db.Users.FirstOrDefault(u=>u.UserID == id).UserName;
            ViewBag.UserId = id;
            IEnumerable<Lists> lists = _db.Lists.Where(l=>l.UserID == id);
            return View("Index", lists);
        }

        [ValidateAntiForgeryToken]
        public PartialViewResult _Submit(Lists list)
        {
            _db.Lists.Add(list);
            _db.SaveChanges();

            List<Lists> lists = _db.Lists.Where(l => l.UserID == list.UserID).ToList();
            ViewBag.UserId = list.UserID;


            return PartialView("_GetForUser", lists);
        }

        public PartialViewResult _ListsForm(Int32 userId)
        {
            Lists list = new Lists() {UserID = userId};
            return PartialView("_ListsForm", list);
        }

        public PartialViewResult _GetForUser(Int32 id)
        {
            ViewBag.Username = _db.Users.FirstOrDefault(u => u.UserID == id).UserName;
            ViewBag.UserId = id;
            IEnumerable<Lists> lists = _db.Lists.Where(l => l.UserID == id);
            return PartialView(lists);
        }

        ////
        //// GET: /Lists/Details/5

        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        ////
        //// GET: /Lists/Create

        //public ActionResult Create()
        //{
        //    return View();
        //}

        ////
        //// POST: /Lists/Create

        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        ////
        //// GET: /Lists/Edit/5

        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        ////
        //// POST: /Lists/Edit/5

        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        ////
        //// GET: /Lists/Delete/5

        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        ////
        //// POST: /Lists/Delete/5

        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
