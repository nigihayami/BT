using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BT.Models;
using BT.DAL;

namespace BT.Controllers
{
    public class TasksController : Controller
    {
        private baseRepository baseRep = new baseRepository();

        public ActionResult Index(int id)
        {
            ViewData["id"] = id;
            var t = baseRep.Tasks.Get(a => a.TProjectsVersions.Id == id).ToList();
            ViewData["StartDay"] = baseRep.ProjectsVersions.GetByID(id).TProjectsVersionsStart;
            if (t.Count == 0)
            {                
                ViewData["EndDay"] = DateTime.Now.AddDays(30.00);
            }
            else
            {
                ViewData["EndDay"] = t.Max(a => a.TTaskEnd) > baseRep.ProjectsVersions.GetByID(id).TProjectsVersionsEnd ? t.Max(a => a.TTaskEnd).AddDays(1.00) : baseRep.ProjectsVersions.GetByID(id).TProjectsVersionsEnd;
            }
            ViewData["data"] = t;
            return View();
        }
        public ActionResult Create(int id)
        {
            ViewData["id"] = id;
            ViewData["TUsers"] = new List<ApplicationUser>(baseRep.Users.Get());            
            return View();
        }
        [HttpPost]
        public ActionResult Create(int id, TTasks tTasks)
        {
            tTasks.TStatus = baseRep.Status.GetByID(1);
            tTasks.TProjectsVersions = baseRep.ProjectsVersions.GetByID(id);
            if (ModelState.IsValid)
            {
                baseRep.Tasks.Ins(tTasks);
                baseRep.Save();
                return RedirectToAction("Index", "Tasks", new { id = id });
            }
            ViewData["id"] = id;
            ViewData["TUsers"] = new List<ApplicationUser>(baseRep.Users.Get());  
            return View(tTasks);
        }
        public ActionResult Details(int id)
        {
            var t = baseRep.Tasks.GetByID(id);
            return View(t);
        }

        protected override void Dispose(bool disposing)
        {
            baseRep.Dispose();
            base.Dispose(disposing);
        }
    }
}
