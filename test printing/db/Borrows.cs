using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbuFas.db
{
    public class Borrows
    {
        [System.ComponentModel.DataAnnotations.Key]
        [System.ComponentModel.DataAnnotations.DatabaseGenerated(System.ComponentModel.DataAnnotations.DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsArchived { get; set; }
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
