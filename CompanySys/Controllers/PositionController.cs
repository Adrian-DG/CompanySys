using CompanySys.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CompanySys.Controllers
{
    public class PositionController : Controller
    {
        private CompanyContext db = new CompanyContext();
        // GET: Position
        public PartialViewResult Index()
        {
            return PartialView();
        }

        public PartialViewResult PositionList()
		{
            var positions = db.Positions.Include(p => p.GetDepartment);
            return PartialView(positions.ToList());
        }

        [HttpGet]
        public PartialViewResult PositionForm()
		{
            ViewBag.DepartmentID = new SelectList(db.Departments, "ID", "Name", "Select Dept.");
            return PartialView();
		}

        [HttpPost]
        public RedirectToRouteResult PositionForm(Position pos)
		{
			if (ModelState.IsValid)
			{
                db.Positions.Add(pos);
                db.SaveChanges();
			}

            ViewBag.DepartmentID = new SelectList(db.Departments, "ID", "Name", pos.DepartmentID);
            return RedirectToAction("Index", "Home");

        }

        [HttpGet]
        public ViewResult Edit(int id)
		{
            ViewBag.DepartmentID = new SelectList(db.Departments, "ID", "Name");
            return View(db.Positions.Find(id));
        }

        [HttpPost]
        public RedirectToRouteResult Edit(Position pos)
		{
            var row = db.Positions.Where(p => p.ID.Equals(pos.ID)).First();
            db.Positions.Remove(row);
            db.Positions.Add(pos);

            db.SaveChanges();
            ViewBag.DepartmentID = new SelectList(db.Departments, "ID", "Name", pos.DepartmentID);
            return RedirectToAction("Index", "Home");
		}

        [HttpGet]
        public ViewResult Details(int id)
		{
            return View(db.Positions.Find(id));
		}

        [HttpGet]
        public ViewResult Delete(int? id)
        {
            return View(db.Positions.Find(id));
        }

        [HttpPost]
        public RedirectToRouteResult Delete(int id)
        {
            var row = db.Positions.Find(id);
            db.Positions.Remove(row);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

    }
}