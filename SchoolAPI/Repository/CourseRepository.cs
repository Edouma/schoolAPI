using Microsoft.AspNetCore.JsonPatch;
using SchoolAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly SchoolDbContext _context;

        public CourseRepository(SchoolDbContext context)
        {
            _context = context;
        }

        public Course Add(Course register)
        {
            _context.Courses.Add(register);
            _context.SaveChanges();
            return register;
        }

        public Course Delete(int id)
        {
            Course course = _context.Courses.Find(id);

            if (course != null)
            {
                _context.Courses.Remove(course);
                _context.SaveChanges();
            }
            return course;
        }
        public Course GetCourseById(int id)
        {
            return _context.Courses.Find(id);
                      
        }

        public IEnumerable<Course> GetAllCourses()
        {
            var records = _context.Courses.ToList();
            return records;
        }

        public Course Update(int id, Course registerChanges)
        {
            var Course = _context.Courses.Find(id);

            if (Course != null)
            {
                Course.CourseName = registerChanges.CourseName;
                _context.SaveChanges();
            }

            return registerChanges;
        }

        public Course UpdatePatch(int id, JsonPatchDocument registerChanges)
        {
            var Course = _context.Courses.Find(id);

            
            if (Course != null)
            {
                registerChanges.ApplyTo(Course);
                _context.SaveChanges();
            }
            return Course;
        }

    }
        
 }
