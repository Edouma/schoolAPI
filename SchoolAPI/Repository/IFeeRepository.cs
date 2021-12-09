using SchoolAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI.Repository
{
   public  interface IFeeRepository
    {
        IEnumerable<Fee> GetFees();
        Fee Add(Fee register);
        Fee GetFeeById(int id);
        Fee Delete(int id);
    }
}
