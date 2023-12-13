﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_printing.db
{

    public class Bills
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
       public string CustomerName { get; set; }
       public string Notes { get; set; }
        public bool IsBuy { get; set; }
        public List<BillData> Data { get; set; }
    }
}
