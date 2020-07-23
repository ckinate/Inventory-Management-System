using Inventory_Management_System.Data.Interfaces;
using Inventory_Management_System.Data.Model;
using Inventory_Management_System.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_Management_System.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _repository;
        public EmployeeController(IEmployeeRepository repository)
        {
            _repository = repository;
        }
        [Route("Employee")]
        public IActionResult List()
        {
            if (!_repository.Any()) return View("Empty");

            var employees = _repository.GetAllWithInventory();

            return View(employees);
        }
        public IActionResult EmployeeDetail()
        {
            var employees = _repository.GetAllWithInventory();

            if (employees?.ToList().Count == 0)
            {
                return View("Empty");
            }

            return View(employees);
        }
        public IActionResult Detail(int id)
        {
            var employee = _repository.GetById(id);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }
        public IActionResult Update(int id)
        {
            var employee = _repository.GetById(id);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(employees employee)
        {
            if (!ModelState.IsValid)
            {
                return View(employee);
            }
            _repository.Update(employee);

            return RedirectToAction("List");
        }
        public ViewResult Create()
        {
            return View(new EmployeeViewModel { Referer = Request.Headers["Referer"].ToString() });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EmployeeViewModel employeeVM)
        {
            if (!ModelState.IsValid)
            {
                return View(employeeVM);
            }

            _repository.Create(employeeVM.Employees);

            if (!String.IsNullOrEmpty(employeeVM.Referer))
            {
                return Redirect(employeeVM.Referer);
            }

            return RedirectToAction("List");
        }
        public IActionResult Delete(int id)
        {
            var employee = _repository.GetById(id);

            _repository.Delete(employee);

            return RedirectToAction("List");
        }
    }
}
