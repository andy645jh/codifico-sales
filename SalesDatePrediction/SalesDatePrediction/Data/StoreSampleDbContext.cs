using Microsoft.EntityFrameworkCore;
using SalesDatePredictionApp.Models.HR;
using SalesDatePredictionApp.Models.Production;
using SalesDatePredictionApp.Models.Sales;

namespace SalesDatePredictionApp.Data
{
    public class StoreSampleDbContext : DbContext
    {
        public DbSet<Employee> Employee { get; set; } = null;
        public DbSet<Product> Product { get; set; } = null;
        public DbSet<Product> ClientOrder { get; set; } = null;
        public DbSet<Shipper> Shipper { get; set; } = null;
        public DbSet<SalesDatePrediction> SalesDatePrediction { get; set; } = null;

        public StoreSampleDbContext(DbContextOptions<StoreSampleDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().ToView("vw_Employees").HasNoKey();
            modelBuilder.Entity<Product>().ToView("vw_Products").HasNoKey();
            modelBuilder.Entity<ClientOrder>().ToView("vw_ClientOrders").HasNoKey();
            modelBuilder.Entity<Shipper>().ToView("vw_Shippers").HasNoKey();
            modelBuilder.Entity<SalesDatePrediction>().ToView("vw_SalesDatePrediction").HasNoKey();
        }        
    }
}


