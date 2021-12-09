using SchoolAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI.Repository
{
    public class FeeRepository : IFeeRepository
    {
        private readonly SchoolDbContext _context;

        public FeeRepository(SchoolDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Fee> GetFees()
        {
            var record = _context.Fees.ToList();
            return record;
        }

        public Fee Add(Fee register)
        {
            _context.Fees.Add(register);
            _context.SaveChanges();
            return register;
        }

        public Fee GetFeeById(int id)
        {
            return _context.Fees.Find(id);
        }
                        
        public Fee Delete(int id)
        {
            Fee fee = _context.Fees.Find(id);

            if (fee != null)
            {
                _context.Fees.Remove(fee);
                _context.SaveChanges();
            }
            return fee;
        }
    }
}

