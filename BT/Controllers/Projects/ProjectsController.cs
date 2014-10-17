using BT.DAL;
using BT.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace BT.Controllers
{
    public class ProjectsController : Controller
    {
        private baseRepository baseRep = new baseRepository();
        // GET: Projects
        public ActionResult Index()
        {
            return View(this.baseRep.ProjectsRepository.Get());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(TProjects tProjects)
        {
            if (baseRep.ProjectsRepository.Any(a => a.TProjectsName == tProjects.TProjectsName))
            {
                ModelState.AddModelError("TProjectsName","Данное название уже существует");
            }
            if (ModelState.IsValid)
            {
                this.baseRep.ProjectsRepository.Ins(tProjects);
                this.baseRep.Save();
                return RedirectToAction("Index");
            }
            return View(tProjects);
        }

        public ActionResult Edit(int id)
        {
            var tProjects = this.baseRep.ProjectsRepository.GetByID(id);
            return View(tProjects);
        }
        [HttpPost]
        public ActionResult Edit(TProjects tProjects)
        {
            if (baseRep.ProjectsRepository.Any(a => a.TProjectsName == tProjects.TProjectsName && a.Id != tProjects.Id))
            {
                ModelState.AddModelError("TProjectsName", "Данное название уже существует");
            }
            if (ModelState.IsValid)
            {
                this.baseRep.ProjectsRepository.Upd(tProjects);
                this.baseRep.Save();
                return RedirectToAction("Index");
            }
            return View(tProjects);
        }
        
        public ActionResult Delete(int id)
        {
            var tProjects = this.baseRep.ProjectsRepository.GetByID(id);
            return View(tProjects);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {            
            this.baseRep.ProjectsRepository.Del(id);
            this.baseRep.Save();
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            this.baseRep.Dispose();
            base.Dispose(disposing);
        }
    }
}
