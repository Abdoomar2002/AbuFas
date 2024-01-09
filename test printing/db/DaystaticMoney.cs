using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

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
        public DaystaticMoney() 
        {
            IncomeOutCome=new List<IncomeOutcome>();
            Bills=new List<Bills>();
            AppDbContext context = new AppDbContext();
             // var item=context.DaystaticMoney.OrderBy(c=>c.Date).LastOrDefault();
         //   if (item != null) Total = item.Total;
         //   else  Total = 0;

        }
        public DaystaticMoney( DateTime date)
        {
            IncomeOutCome = new List<IncomeOutcome>();
            Bills = new List<Bills>();
            AppDbContext context = new AppDbContext();
            var item = context.DaystaticMoney.OrderBy(b=>b.Date).Where(d=>d.Date<date).LastOrDefault();
            if (item != null) Total = item.Total;
            else Total = 0;

        }

    }
}
