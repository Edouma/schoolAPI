using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using SchoolAPI.Data;
using SchoolAPI.Repository;

namespace SchoolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository _context;

        public CourseController(ICourseRepository context)
        {
            _context = context;
        }

        [HttpGet("Get-All-Courses")]
        public IActionResult GetAllCourses()
        {
            var courses = _context.GetAllCourses();
            return Ok(courses);
        }

        [HttpGet("CourseById/{id}")]
        public IActionResult GetCourseById([FromRoute] int id)
        {
            var course = _context.GetCourseById(id);

            return Ok(course);
        }

        [HttpPost("")]
        public IActionResult AddCourse([FromBody] Course register)
        {
            var course = _context.Add(register);
            if (course == null)
            {
                return NotFound();
            }
            return Ok(course);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCourse([FromBody] Course courseModel, [FromRoute] int id)
        {
            var course = _context.Update(id, courseModel);
            return Ok(course);
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateCoursePatch([FromBody] JsonPatchDocument courseModel, [FromRoute] int id)
        {
            var course = _context.UpdatePatch(id, courseModel);
            return Ok(course);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            _context.Delete(id);
            return Ok();
        }
    }
}
