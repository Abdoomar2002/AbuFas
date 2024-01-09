using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbuFas.db
{
    public class Customers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsArchived { get; set; }
        public DateTime Date { get;set; }
        public string Notes { get; set; }
        public double TotalGrams { get; set; }
        public double TotalMoney { get; set; }
        public ICollection<CustomersData> Data { get; set; }

    public Customers() 
        {
            Data = new List<CustomersData>();
        }



    }
}
