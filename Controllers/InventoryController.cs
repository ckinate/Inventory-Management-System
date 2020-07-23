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
    public class InventoryController : Controller
    {
        private readonly IinventoryRepository _repository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IWarehouseRepository _warehouseRepository;

        public InventoryController(IinventoryRepository repository, IEmployeeRepository employeeRepository, IWarehouseRepository warehouseRepository)
        {
            _repository = repository;
            _employeeRepository = employeeRepository;
            _warehouseRepository = warehouseRepository;

        }
        [Route("Inventory")]
        public IActionResult List(int? productId)
        {

            var inventory = _repository.GetAllWithWarehouse().ToList();

            IEnumerable<inventoryItems> inventories;

            ViewBag.WarehouseId = productId;

            if (productId != null)
            {
                inventories = _repository.FindWithEmployeeAndWarehouse(a => a.WarehouseId == productId);
                return CheckInventoryCount(inventories);
            }

            if (productId == null)
            {
                inventories = _repository.GetAllWithWarehouse();
                return CheckInventoryCount(inventories);
            }
            else
            {
                var product = _warehouseRepository.GetWithInventory((int) productId);

                if (product.Inventory == null || product.Inventory.Count == 0)
                    return View("EmptyWarehouse", product);
            }

            inventories = _repository.Find(a => a.Warehouse.warehouseId == productId);

            return CheckInventoryCount(inventories);
        }
        private IActionResult CheckInventoryCount(IEnumerable<inventoryItems> Inventories)
        {
            if (Inventories == null || Inventories.ToList().Count == 0)
            {
                return View("Empty");
            }
            else
            {
                return View(Inventories);
            }
        }
        public IActionResult Update(int id)
        {
            inventoryItems inventory = _repository.FindWithWarehouse(a => a.inventoryItemsId == id).FirstOrDefault();
            inventoryItems inventory1 = _repository.FindWithEmployee(a => a.inventoryItemsId == id).FirstOrDefault();

            if (inventory == null)
            {
                return NotFound();
            }
            if (inventory1 == null)
            {
                return NotFound();
            }

            var InventoryVM = new InventoryViewModel
            {
                Inventory = inventory,
                Warehouses = _warehouseRepository.GetAll(),
                Employee = _employeeRepository.GetAll()
            };

            return View(InventoryVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(InventoryViewModel InventoryVM)
        {
            if (!ModelState.IsValid)
            {

                InventoryVM.Employee = _employeeRepository.GetAll();
                InventoryVM.Warehouses = _warehouseRepository.GetAll();
                return View(InventoryVM);
            }
            _repository.Update(InventoryVM.Inventory);

            return RedirectToAction("List");
        }
        public IActionResult Create(int? warehouseId,int? employeeId)
        {
          
            inventoryItems inventory = new inventoryItems();

            if (warehouseId != null)
            {
                inventory.WarehouseId = (int)warehouseId;
            }
            if (employeeId != null)
            {
                inventory.EmployeeId = (int)employeeId;
            }

            var InventoryVM = new InventoryViewModel
            {
                Employee = _employeeRepository.GetAll(),
                Warehouses = _warehouseRepository.GetAll(),
                Inventory = inventory
            };

            return View(InventoryVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(InventoryViewModel inventoryVM)
        {
            if (!ModelState.IsValid)
            {
                inventoryVM.Employee = _employeeRepository.GetAll();
                inventoryVM.Warehouses = _warehouseRepository.GetAll();
                return View(inventoryVM);
            }

            _repository.Create(inventoryVM.Inventory);

            return RedirectToAction("List");
        }

        public IActionResult Delete(int id, int? warehouseId)
        {
            var inventory = _repository.GetById(id);

            _repository.Delete(inventory);

            return RedirectToAction("List", new { warehouseId = warehouseId });

        }
    }
}
