using Inventory_Management_System.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_Management_System.Data.Interfaces
{
   public interface IinventoryRepository : IRepository<inventoryItems>
    {
        IEnumerable<inventoryItems> GetAllWithEmployee();
        IEnumerable<inventoryItems> FindWithEmployee(Func<inventoryItems, bool> predicate);
        IEnumerable<inventoryItems> FindWithEmployeeAndWarehouse(Func<inventoryItems, bool> predicate);
        IEnumerable<inventoryItems> GetAllWithWarehouse();
        IEnumerable<inventoryItems> FindWithWarehouse(Func<inventoryItems, bool> predicate);
    }
}
