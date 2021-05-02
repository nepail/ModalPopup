using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModalPopup.Data;
using ModalPopup.Models;

namespace ModalPopup.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var listofEmployees = _context.Employees.ToList();
            return View(listofEmployees);
        }
        [HttpGet]
        public IActionResult Create()
        {
            Employee emp = new Employee();
            return PartialView("_EmployeeModelPartial", emp);
        }
        [HttpPost]
        public IActionResult Create(Employee emp)
        {
            _context.Employees.Add(emp);
            _context.SaveChanges();
            return PartialView("_EmployeeModelPartial", emp);
        }

        public IActionResult Edit(int id)
        {
            var employee = _context.Employees.Where(x => x.Id == id).FirstOrDefault();
            return PartialView("_EditEmployeeModelPartial", employee);
        }

        [HttpPost]
        public IActionResult Edit(Employee emp)
        {
            _context.Employees.Update(emp);
            _context.SaveChanges();
            return PartialView("_EditEmployeeModelPartial", emp);
        }

        public IActionResult Details(int id)
        {
            var employee = _context.Employees.Where(x => x.Id == id).FirstOrDefault();
            return PartialView("_DetailEmployeeModelPartail", employee);
        }

        public IActionResult Delete(int id)
        {
            var employee = _context.Employees.Where(x => x.Id == id).FirstOrDefault();
            return PartialView("_DeleteEmployeeModelPartial", employee);
        }

        [HttpPost]
        public IActionResult Delete(Employee emp)
        {
            //var employee = _context.Employees.Where(x => x.Id == emp.Id).FirstOrDefault();
            _context.Employees.Remove(emp);
            _context.SaveChanges();
            return PartialView("_DeleteEmployeeModelPartial", emp);
        }

    }
}
