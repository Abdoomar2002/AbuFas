using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbuFas.db
{
    public class CustomersData
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Price { get; set; }
        public double Grams { get; set; }
        public string Notes { get; set; }
        public bool IsIncome { get; set; }
        [System.ComponentModel.DataAnnotations.ForeignKey("CustomerId")]
        public virtual Customers Customer { get; set; }
    }
}
