using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using System.Web.Mvc;
using TestMVCApp.Models;

namespace TestMVCApp.Controllers
{
    public class EmployeeController : Controller
    {
        private TestDatabaseEntities db = new TestDatabaseEntities();

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAllEmployees()
        {
            var employeeList = db.EmployeeInfoes.ToList();
            return Json(employeeList, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetEmployeesBySalaryAsc()
        {
            var employeeList = db.EmployeeInfoes.OrderBy(e => e.Salary).ToList();
            var models = new List<EmployeeVM>();

            foreach (var e in employeeList)
            {
                models.Add(new EmployeeVM
                {
                    EmpNo = e.EmpNo,
                    EmpName = e.EmpName,
                    DeptName = e.DeptName,
                    Designation = e.Designation,
                    Salary = e.Salary
                });
            }       

            var returnVal = Json(models, JsonRequestBehavior.AllowGet);

            return returnVal;
        }

        public class EmployeeVM
        {
               
            public int EmpNo { get; set; }
            public string EmpName { get; set; }
            public decimal Salary { get; set; }
            public string DeptName { get; set; }
            public string Designation { get; set; }
        }
    }
}