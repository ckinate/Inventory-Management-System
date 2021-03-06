﻿using Inventory_Management_System.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_Management_System.Data.Interfaces
{
   public interface IWarehouseRepository: IRepository<warehouse>
    {
        IEnumerable<warehouse> GetAll();
        warehouse Get(int id);
        IEnumerable<warehouse> GetAllWithInventory();
        warehouse GetWithInventory(int id);
    }
}
