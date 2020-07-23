using Inventory_Management_System.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory_Management_System.ViewModel;

namespace Inventory_Management_System.Data
{
    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options)
        {
          
        }
        public DbSet<inventoryItems> InventoryItems { get; set; }
        public DbSet<employees> Employees { get; set; }
        public DbSet<warehouse> Warehouses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<inventoryItems>()
               .HasOne(b => b.Warehouse)
               .WithMany()
               .HasForeignKey(a =>a.WarehouseId);

            base.OnModelCreating(builder);
        }

        public DbSet<Inventory_Management_System.ViewModel.WarehouseViewModel> WarehouseViewModel { get; set; }

        public DbSet<Inventory_Management_System.ViewModel.EmployeeViewModel> EmployeeViewModel { get; set; }

        public DbSet<Inventory_Management_System.ViewModel.InventoryViewModel> InventoryViewModel { get; set; }
    }
}
