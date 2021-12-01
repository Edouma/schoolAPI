using Microsoft.AspNetCore.Mvc;
using SchoolAPI.Data;
using SchoolAPI.Repository;

namespace SchoolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IstudentRepository _context;

        public StudentsController(IstudentRepository context)
        {
            _context = context;
        }

        [HttpGet("")]
        public IActionResult GetStudents()
        {
            var students = _context.GetStudents();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public IActionResult GetStudentById([FromRoute]int id)
        {
            var student = _context.GetStudentById(id);
            return Ok(student);
        }

        [HttpPost("")]
        public IActionResult AddStudent([FromBody]Student register)
        {
          var student =  _context.Add(register);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent([FromBody] Student studentModel, [FromRoute] int id)
        {
            var student = _context.Update(id, studentModel);
            return Ok(student);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            _context.Delete(id);
            return Ok();
        }

    }
}
