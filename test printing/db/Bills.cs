using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_printing.db
{

    public class Bills
    {
        [System.ComponentModel.DataAnnotations.Key]
        [System.ComponentModel.DataAnnotations.DatabaseGenerated(System.ComponentModel.DataAnnotations.DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
       public string CustomerName { get; set; }
       public string Notes { get; set; }
        public bool IsBuy { get; set; }
        public double Total {get; set; }
        public  DateTime Date { get; set; }
        [System.ComponentModel.DataAnnotations.ForeignKey("MoneyId")]
        public virtual DaystaticMoney Money { get; set; }
        public ICollection<BillData> Data { get; set; }
        public Bills() 
        {
            Data = new List<BillData>();
        }  
    }
}
