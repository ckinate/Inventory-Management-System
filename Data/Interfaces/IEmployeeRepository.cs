using Inventory_Management_System.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_Management_System.Data.Interfaces
{
   public interface IEmployeeRepository :IRepository<employees>
    {
        IEnumerable<employees> GetAllWithInventory();
        employees GetWithInventory(int id);

    }
}
