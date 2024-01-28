using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_printing.db
{
    public class IncomeOutcome
    {
        [Key]
        [System.ComponentModel.DataAnnotations.DatabaseGenerated(System.ComponentModel.DataAnnotations.DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public double Price { get; set; }
        public string Notes { get; set; }
        public bool IsIncome { get; set; }
        [System.ComponentModel.DataAnnotations.ForeignKey("MoneyId")]
        public virtual DaystaticMoney Money { get; set; }
        public IncomeOutcome() { }
    }
}
