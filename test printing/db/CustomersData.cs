using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [ForeignKey("CustomerId")]
        public int CustomerId { get; set; }
        public Customers Customer { get; set; }
    }
}
