using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test_printing.db;

namespace AbuFas.db
{
    public class BorrowsData
    {
        [Key]
        [System.ComponentModel.DataAnnotations.DatabaseGenerated(System.ComponentModel.DataAnnotations.DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public double Incoume { get; set; }
        public DateTime Date { get; set; }
        public double Outcome { get; set; }
        public string Notes { get; set; }
        [System.ComponentModel.DataAnnotations.ForeignKey("BorrowId")]
        public virtual Borrows Borrow { get; set; }

    }
}
