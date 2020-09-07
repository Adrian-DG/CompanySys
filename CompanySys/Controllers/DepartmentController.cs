using CompanySys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CompanySys.Controllers
{
    public class DepartmentController : Controller
    {
        // Database Access
        private CompanyContext db = new CompanyContext();

        // GET: Departement
        public PartialViewResult Index()
        {
            return PartialView();
        }

        [HttpGet]
        public PartialViewResult DepartmentList() {
            return PartialView(db.Departments.ToList());
        }

        public PartialViewResult DepartmentForm()
		{
            return PartialView();
		}

        [HttpPost]
        public RedirectToRouteResult DepartmentForm(Department dept)
        {
			if (ModelState.IsValid)
			{
                db.Departments.Add(dept);
                db.SaveChanges();
			}

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ViewResult Edit(int id)
		{
            var dept = db.Departments.Where(d => d.ID.Equals(id)).First();
            return View(dept);
        }

        [HttpPost]
        public RedirectToRouteResult Edit(Department dept)
		{
            var row = db.Departments.Where(x => x.ID.Equals(dept.ID)).First();
            db.Departments.Remove(row);
            db.Departments.Add(dept);

            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ViewResult Details(int id)
		{
            var dept = db.Departments.Where(d => d.ID.Equals(id)).First();
            return View(dept);
		}

        [HttpGet]
        public ViewResult Delete(int id)
        {
            var dept = db.Departments.Where(d => d.ID.Equals(id)).First();
            return View(dept);
        }

        [HttpPost]
        public RedirectToRouteResult Delete(Department dept)
        {
            db.Departments.Remove(dept);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

    }
}