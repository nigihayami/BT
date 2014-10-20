using BT.DAL;
using BT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BT.Controllers
{
    public class ProjectsVersionsController : Controller
    {
        private baseRepository baseRep = new baseRepository();

        public ActionResult Index(int id)
        {
            ViewData["id"] = id;
            return View(baseRep.ProjectsVersions.Get(a => a.TProjects.Id == id));
        }
        public ActionResult Create(int id)
        {
            ViewData["id"] = id;
            return View();
        }
        [HttpPost]
        public ActionResult Create(int id, TProjectsVersions t)
        {
            t.TProjects = baseRep.ProjectsRepository.GetByID(id);
            t.TStatus = baseRep.Status.GetByID(1);
            if(baseRep.ProjectsVersions.Any(a => a.TProjects.Id == id && a.TProjectsVersionsCode == t.TProjectsVersionsCode))
            {
                ModelState.AddModelError("TProjectsVersionsCode", "Данный код уже присутствует в данной версии");
            }
            if(baseRep.ProjectsVersions.Any(a => a.TProjects.Id == id))
            {
                //если есть проекты
                if(baseRep.ProjectsVersions.Any(a => a.TProjects.Id == id && t.TProjectsVersionsStart >= a.TProjectsVersionsStart && t.TProjectsVersionsStart <= a.TProjectsVersionsEnd))
                {
                    //Пересечение даты начала
                    ModelState.AddModelError("TProjectsVersionsStart", "Пересечение даты с остальными версиями");
                }
                if (baseRep.ProjectsVersions.Any(a => a.TProjects.Id == id && t.TProjectsVersionsEnd >= a.TProjectsVersionsStart && t.TProjectsVersionsEnd <= a.TProjectsVersionsEnd))
                {
                    //Пересечение даты окончания
                    ModelState.AddModelError("TProjectsVersionsEnd", "Пересечение даты с остальными версиями");
                }
            }
            if (ModelState.IsValid)
            {
                baseRep.ProjectsVersions.Ins(t);
                baseRep.Save();
                return RedirectToAction("Index", new { id = id });
            }
            ViewData["id"] = id;
            return View(t);
        }
        protected override void Dispose(bool disposing)
        {
            baseRep.Dispose();
            base.Dispose(disposing);
        }
    }
}