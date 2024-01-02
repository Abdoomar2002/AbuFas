using AbuFas;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace test_printing
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /*    void ConfigureServices(IServiceCollection services)
               {
                   // Other services...

                   // Configure Entity Framework with SQLite
                   services.AddDbContext<AppDbContext>(options =>
                       options.UseSqlite(Configuration.GetConnectionString("DefaultConnection"))
                   );

                   // Other configurations...
               }*/
            SQLitePCL.Batteries.Init();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new login());
        }
    }
}
