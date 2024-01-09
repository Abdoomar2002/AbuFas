using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_printing.db
{
    public class BillData
    {
       public int Id { get; set; }
        public double Price { get; set; }
        public double Weight { get; set; }
        public double Type { get; set; }
        public int Kyrat { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        [ForeignKey("BillId")]
        public int BillId { get; set; }
        public Bills Bill { get; set; }

    }
}
