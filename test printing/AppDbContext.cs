using Microsoft.EntityFrameworkCore;

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

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) 
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=AbuFas.db");
          /*  base.OnConfiguring(optionsBuilder);
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AbuFas;Trusted ");
                
            }*/
        }
       
        public AppDbContext() { }

    }
}
