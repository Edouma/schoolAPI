using Microsoft.AspNetCore.Mvc;
using SchoolAPI.Data;
using SchoolAPI.Repository;

namespace SchoolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeeController : ControllerBase
    {
        private readonly IFeeRepository _context;

        public FeeController(IFeeRepository context)
        {
            _context = context;
        }
        [HttpGet("Get-All-Fees-Paid")]
        public IActionResult GetAllCFees()
        {
            var fees = _context.GetFees();
            return Ok(fees);
        }

        [HttpGet("FeeById/{id}")]
        public IActionResult GetFeeById([FromRoute] int id)
        {
            var fee = _context.GetFeeById(id);

            return Ok(fee);
        }

        [HttpPost("")]
        public IActionResult AddFee([FromBody] Fee register)
        {
            var fee = _context.Add(register);
            if (fee == null)
            {
                return NotFound();
            }
            return Ok(fee);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            _context.Delete(id);
            return Ok();
        }
    }
}
