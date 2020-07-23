using Inventory_Management_System.Data.Interfaces;
using Inventory_Management_System.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_Management_System.Data.Repository
{
    public class InventoryRepository : Repository<inventoryItems>, IinventoryRepository
    {
        public InventoryRepository(InventoryDbContext context): base(context)
        {

        }

        public IEnumerable<inventoryItems> FindWithWarehouse(Func<inventoryItems, bool> predicate)
        {
            return _context.InventoryItems
                .Include(a => a.Warehouse)
                .Where(predicate); ;
        }
        public IEnumerable<inventoryItems> FindWithEmployee(Func<inventoryItems, bool> predicate)
        {
            return _context.InventoryItems
                .Include(a => a.Employees)
                .Where(predicate); ;
        }

        public IEnumerable<inventoryItems> FindWithEmployeeAndWarehouse(Func<inventoryItems, bool> predicate)
        {
            return _context.InventoryItems
              .Include(a => a.Employees)
              .Include(a => a.Warehouse)
              .Where(predicate); ;
        }

        public IEnumerable<inventoryItems> GetAllWithWarehouse()
        {
            return _context.InventoryItems.Include(a => a.Warehouse);
            ;
        }
        public IEnumerable<inventoryItems> GetAllWithEmployee()
        {
            return _context.InventoryItems.Include(a => a.Employees);
            ;
        }
    }
}
