using CompanySys.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CompanySys.Controllers
{
    public class EmployeeController : Controller
    {
        private CompanyContext db = new CompanyContext();
        // GET: Employee
        public PartialViewResult Index()
        {
            return PartialView();
        }

        public PartialViewResult EmployeeList()
		{
            var employees = db.Employees.Include(x => x.GetDepartment).Include(x => x.GetPosition);
            return PartialView(employees.ToList());
        }

        public PartialViewResult EmployeeForm()
		{
            ViewBag.PositionID = new SelectList(db.Positions, "ID", "Name", "Select Position");
            ViewBag.DepartmentID = new SelectList(db.Departments, "ID", "Name", "Select Department");
            return PartialView();
		}

        [HttpPost]
        public RedirectToRouteResult EmployeeForm(Employee employee)
		{
            string foldername = "~/IMGS/";
            string filename = Path.GetFileNameWithoutExtension(employee.Upload.FileName);
            string extension = Path.GetExtension(employee.Upload.FileName);

            filename = $"{filename}{DateTime.Now.ToString("yymmssfff")}{extension}";
            string filePath = Path.Combine(Server.MapPath(foldername), filename);

            employee.Image = $"{foldername}{filename}";
            employee.Upload.SaveAs(filePath);

            db.Employees.Add(employee);
            db.SaveChanges();

            return RedirectToAction("Index", "Home");

        }

        [HttpGet]
        public ViewResult Edit(int id)
		{
            var employee = db.Employees.Where(x => x.ID == id).First();
            ViewBag.PositionID = new SelectList(db.Positions, "ID", "Name", "Select Position");
            ViewBag.DepartmentID = new SelectList(db.Departments, "ID", "Name", "Select Department");
            return View(employee);
		}

        [HttpPost]
        public RedirectToRouteResult Edit(Employee employee)
        {
            var row = db.Employees.Where(x => x.ID == employee.ID).First();
            db.Employees.Remove(row);
            db.Employees.Add(employee);
            db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ViewResult Delete(int id)
        {
            var employee = db.Employees.Where(x => x.ID == id).First();
            return View(employee);
        }

        [HttpPost]
        public RedirectToRouteResult Delete(Employee employee)
        {
            var row = db.Employees.Where(x => x.ID == employee.ID).First();
            db.Employees.Remove(row);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ViewResult Details(int id)
        {
            var employee = db.Employees.Find(id);
            return View(employee);
        }

        

        

		
	}
}