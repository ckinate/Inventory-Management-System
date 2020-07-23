using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_Management_System.Data.Model
{
    public class inventoryItems
    {
        [Key]
        public int inventoryItemsId { get; set; }
        public string inventoryName { get; set; }
        public virtual warehouse Warehouse { get; set; }
        public string ProductName { get; set; }
        public int WarehouseId { get; set; }
        public virtual employees Employees { get; set; }
        public int EmployeeId { get; set; }
       

    }
}
