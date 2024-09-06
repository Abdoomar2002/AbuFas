using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbuFas.db
{
    public class Cust 
    {
        [Key]
        [System.ComponentModel.DataAnnotations.DatabaseGenerated(System.ComponentModel.DataAnnotations.DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsArchived { get; set; }
        public DateTime Date { get; set; }
        public string Notes { get; set; }
        public double TotalGrams { get; set; }
        public double TotalMoney { get; set; }
        public ICollection<CustData> Data { get; set; }=new List<CustData>();
    }
    public class CustData  
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Price { get; set; }
        public double Grams { get; set; }
        public string Notes { get; set; }
        public bool IsIncome { get; set; }
        [System.ComponentModel.DataAnnotations.ForeignKey("CustId")]
        public virtual Cust Customer { get; set; }
    }
}
