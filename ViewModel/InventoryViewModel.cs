using Inventory_Management_System.Data.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_Management_System.ViewModel
{
    public class InventoryViewModel
    {
        [Key]
        public int Id { get; set; }
        public inventoryItems Inventory { get; set; }

        public IEnumerable<employees> Employee { get; set; }
        public IEnumerable<warehouse> Warehouses { get; set; }


    }
}
