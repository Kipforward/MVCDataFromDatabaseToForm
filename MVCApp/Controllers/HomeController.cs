using MVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLibrary;
using static DataLibrary.BusinessLogic.EmployeeProcessor;

namespace MVCApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page";

            return View();
        }

        public ActionResult ViewEmployees()
        {
            ViewBag.Message = "Employees List";

            var data = LoadEmployees();
            List<Employee> employees = new List<Employee>(); 

            foreach(var row in data)
            {
                employees.Add(new Employee
                {
                    EmployeeId = row.EmployeeId,
                    FirstName = row.FirstName,
                    LastName = row.LastName,
                    EmailAddress = row.EmailAddress,
                    ConfirmEmail = row.EmailAddress
                });
            }
            return View(employees);
        }

        public ActionResult SignUp()
        {
            ViewBag.Message = "Employee Sign Up.";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(Employee model)
        {
            if(ModelState.IsValid)
            {
                // call the business logic
                int recordsCreated = CreateEmployee(model.EmployeeId, 
                               model.FirstName, 
                               model.LastName, 
                               model.EmailAddress);
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}