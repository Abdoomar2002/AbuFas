using AbuFas.db;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using test_printing.db;

namespace test_printing
{
    public  class AppDbContext : DbContext
    {
        public DbSet<BillData> BillData { get; set; }
        public DbSet<Bills> Bills { get; set; }
        public DbSet<DayStaticGrams> DayStaticGrams { get; set; }
        public DbSet<DaystaticMoney> DaystaticMoney { get; set; }
        public DbSet<IncomeOutcome> IncomeOutcome { get; set; }
        public DbSet<Customers>Customers { get; set; }
        public DbSet<CustomersData> CustomersData { get; set; }
        public DbSet<Borrows> Borrows { get; set; }
        public DbSet<BorrowsData>BorrowsData { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) 
        {
        }
      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data source=AbuFas.db");

            }
          
            /*  base.OnConfiguring(optionsBuilder);
             */
        }
    
        public AppDbContext() { }

    }
}
