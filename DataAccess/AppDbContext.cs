using Data.EventStore.SQL;
using Data.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace Data.Migrations
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductDescription> ProductDescription { get; set; }
        public DbSet<ProductType> ProductType { get; set; }
        public DbSet<ProductType_Brand> ProductTypesBrand { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<InventoryItem> InventoryItem { get; set; }
        public DbSet<ProductItem> ProductItem { get; set; }
        public DbSet<Shipment> Shipment { get; set; }
        public DbSet<Shipment_StatusLog> ShipmentStatusLogs { get; set; }
        public DbSet<ShipmentStatus> ShipmentStatus { get; set; }
        public DbSet<ProductOrder> ProductsOrder { get; set; }
    }
}
