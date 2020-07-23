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
    public class WarehouseController : Controller
    {
        private readonly IWarehouseRepository _repository;
        public WarehouseController(IWarehouseRepository repository)
        {
            _repository = repository;
        }
        [Route("Warehouse")]
        public IActionResult List()
        {
            if (!_repository.Any()) return View("Empty");

            List<WarehouseViewModel> warehouseVM = new List<WarehouseViewModel>();

            var warehouses = _repository.GetAll();

            foreach (var warehouse in warehouses)
            {
                warehouseVM.Add(new WarehouseViewModel
                {
                    Warehouse = warehouse,

                });
            }

            return View(warehouseVM);
        }

        public IActionResult Update(int id)
        {
            warehouse Warehouse = _repository.GetById(id);

            if (Warehouse == null)
            {
                return NotFound();
            }

            return View(Warehouse);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(warehouse Warehouse)
        {
            if (!ModelState.IsValid)
            {
                return View(Warehouse);
            }
            _repository.Update(Warehouse);

            return RedirectToAction("List");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(warehouse Warehouse)
        {
            if (!ModelState.IsValid)
            {
                return View(Warehouse);
            }

            _repository.Create(Warehouse);

            return RedirectToAction("List");
        }

        public IActionResult Delete(int id)
        {
            var Warehouse = _repository.GetById(id);

            _repository.Delete(Warehouse);

            return RedirectToAction("List");
        }
    }
}
