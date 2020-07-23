using Inventory_Management_System.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_Management_System.ViewModel
{
    public class WarehouseViewModel
    {
        public int Id { get; set; }
        public warehouse Warehouse { get; set; }
        public int ProductInWarehouseCount { get; set; }
    }
}
