using BussinessLayer.Interface;
using DatabaseLayer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePayroll_Ado_Mvc.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeBL employeeBL;
        public EmployeeController(IEmployeeBL employeeBL)
        {
            this.employeeBL = employeeBL;
        }
        // Show employee list
        public IActionResult ListOfEmployee()
        {
            List<EmployeeModel> allEmployees = new List<EmployeeModel>();
            allEmployees = employeeBL.GetAllEmployees().ToList();
            return View(allEmployees);
        }
        [HttpGet]
        public IActionResult EmployeeDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EmployeeModel employee = employeeBL.EmployeeDetails(id);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost]
        public IActionResult EmployeeDetails(int id, [Bind] EmployeeModel employee)
        {
            if (id != employee.EmployeeId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                employeeBL.EmployeeDetails(id);
                return RedirectToAction("ListOfEmployee");
            }
            return View(employee);
        }


        //For adding new employee

        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddEmployee([Bind] EmployeeModel employee)
        {
            if (ModelState.IsValid)
            {
                employeeBL.AddEmployee(employee);
                return RedirectToAction("ListOfEmployee");
            }
            return View(employee);
        }

        //To delete the particular employee
        [HttpGet]
        public IActionResult DeleteEmployee(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EmployeeModel employee = employeeBL.EmployeeDetails(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost, ActionName("DeleteEmployee")]
        public IActionResult DeleteConfirmed(int? id)
        {
            employeeBL.DeleteEmployee(id);
            return RedirectToAction("ListOfEmployee");
        }

        //For updating employee details
        [HttpGet]
        public IActionResult UpdateEmployee(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EmployeeModel employee = employeeBL.EmployeeDetails(id);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost]
        public IActionResult UpdateEmployee(int id, [Bind] EmployeeModel employee)
        {
            if (id != employee.EmployeeId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                employeeBL.UpdateEmployee(employee);
                return RedirectToAction("ListOfEmployee");
            }
            return View(employee);
        }
    }
}
