using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Inventory_Management_System.Models;
using Inventory_Management_System.Data.Interfaces;
using Inventory_Management_System.ViewModel;

namespace Inventory_Management_System.Controllers
{
    public class HomeController : Controller
    {
        private readonly IinventoryRepository _repository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IWarehouseRepository _Warehouserepository;

        public HomeController(IinventoryRepository repository, IEmployeeRepository employeeRepository, IWarehouseRepository Warehouserepository)
        {
            _repository = repository;
            _employeeRepository = employeeRepository;
            _Warehouserepository = Warehouserepository;
        }
        public IActionResult Index()
        {
            var homeVM = new HomeViewModel
            {
                EmployeeCount = _employeeRepository.Count(x => true),
                ProductInWarehouseCount = _Warehouserepository.Count(x => true),
                InventoryCount = _repository.Count(x => true),
                
            };

            return View(homeVM);
        }




    }
}
