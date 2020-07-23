using Inventory_Management_System.Data.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_Management_System.ViewModel
{
    public class EmployeeViewModel
    {
        [Key]
        public int Id { get; set; }
        public employees Employees { get; set; }
        public string Referer { get; set; }
    }
}
