using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_Management_System.Data.Model
{
    public class warehouse
    {
        
        [Key]
        public int warehouseId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string warehouseName { get; set; }
        public employees EmployeeId { get; set; }
        public ICollection<inventoryItems> Inventory { get; set; }
    }
}
