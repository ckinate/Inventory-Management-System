using Inventory_Management_System.Data.Interfaces;
using Inventory_Management_System.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_Management_System.Data.Repository
{
    public class WarehouseRepository:  Repository<warehouse>,IWarehouseRepository
    {
        public WarehouseRepository(InventoryDbContext context) : base(context)
        {
        }

      public  IEnumerable<warehouse> GetAll()
        {
            return _context.Warehouses;
        }
       public warehouse Get(int id)
        {
            return _context.Warehouses.Where(a => a.ProductId == id).FirstOrDefault();
        }
        public void Delete(warehouse entity)
        {
            _context.InventoryItems.Where(b => b.Warehouse == entity)
                .ToList()
                .ForEach(a =>
                {
                    a.Warehouse = null;
                    a.WarehouseId = 0;
                });

            base.Delete(entity);
        }
        public IEnumerable<warehouse> GetAllWithInventory()
        {
            return _context.Warehouses.Include(a => a.Inventory);
        }
        public warehouse GetWithInventory(int id)
        {
            return _context.Warehouses.Where(a => a.warehouseId == id).Include(a => a.Inventory).FirstOrDefault();
        }
    }
}

