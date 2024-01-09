using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test_printing.db;

namespace AbuFas.db
{
    public class BorrowsData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public double Incoume { get; set; }
        public DateTime Date { get; set; }
        public double Outcome { get; set; }
        public string Notes { get; set; }
        [ForeignKey("BorrowId")]
        public int BorrowId { get; set; }
        public Borrows Borrow { get; set; }

    }
}
