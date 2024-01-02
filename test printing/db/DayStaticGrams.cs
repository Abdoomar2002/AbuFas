using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_printing.db
{
    public class DayStaticGrams
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public double Sell { get; set; }
        public double Buy { get; set; }
        public double Bouns { get; set; }

        public double Minus { get; set; }
        public double Damaged { get; set; }
        public DayStaticGrams() { }


    }
}
