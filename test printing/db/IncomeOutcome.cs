using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_printing.db
{
    public class IncomeOutcome
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public double Price { get; set; }
        public string Notes { get; set; }
        public bool IsIncome { get; set; }
        public DaystaticMoney Money { get; set; }
        public IncomeOutcome() { }
    }
}
