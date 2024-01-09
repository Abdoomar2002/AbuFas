using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbuFas.db
{
    public class Borrows
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public double Total { get; set; }
        public DateTime Date { get; set; }
        public ICollection<BorrowsData> BData { get; set; } = new List<BorrowsData>();
        public Borrows() 
        {
            BData = new List<BorrowsData>();
        }
    }
}
