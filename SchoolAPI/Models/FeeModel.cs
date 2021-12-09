using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI.Models
{
    public class FeeModel
    {
        public int Id { get; set; }
        public double AmountPaid { get; set; }
        public DateTime DatePaid { get; set; }
        public double balance { get; set; }
    }
}
