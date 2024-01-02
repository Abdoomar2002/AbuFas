using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test_printing.db;

namespace test_printing.db
{
    public class DaystaticMoney

    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public bool Type {get; set; }
        public double Total {get; set; }
     public  ICollection<IncomeOutcome> IncomeOutCome { get; set; }
       public  ICollection<Bills> Bills { get; set; }
        public DaystaticMoney() { }

    }
}
