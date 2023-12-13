using Microsoft.EntityFrameworkCore;
using test_printing.db;
namespace test_printing
{
    public  class AppDbContext :DbContext
    {
        public DbSet<Bills> Bills { get; set; }
        public DbSet<BillData> BillData { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) 
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AbuFas;Integrated Security=True;Connect Timeout=30;Encrypt=False");
            }
        }
        public AppDbContext() { }

    }
}
