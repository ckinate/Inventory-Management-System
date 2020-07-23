using Inventory_Management_System.Data.Interfaces;
using Inventory_Management_System.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Inventory_Management_System.Data.Repository
{
    public class EmployeeRepository: Repository<employees>, IEmployeeRepository
    {
        public EmployeeRepository(InventoryDbContext context): base(context)
        {

        }

        public IEnumerable<employees> GetAllWithInventory()
        {
            return _context.Employees.Include(a => a.Inventory);
        }

        public employees GetWithInventory(int id)
        {
            return _context.Employees.Where(a => a.employeeId == id).Include(a => a.Inventory).FirstOrDefault();
        }
        public void Delete(employees entity)
        {
            // https://github.com/aspnet/EntityFrameworkCore/issues/3924
            // EF Core 2 doesnt support Cascade on delete for in Memory Database

            var InventoryToRemove = _context.InventoryItems.Where(b => b.Employees == entity);

            base.Delete(entity);

            _context.InventoryItems.RemoveRange(InventoryToRemove);

            Save();
        }

    }
}
