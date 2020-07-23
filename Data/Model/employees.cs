using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_Management_System.Data.Model
{
    public class employees
    {
        [Key]
        public int employeeId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public ICollection<inventoryItems> Inventory { get; set; }

    }
}
