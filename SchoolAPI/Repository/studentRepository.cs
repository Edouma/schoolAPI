using Microsoft.AspNetCore.JsonPatch;
using SchoolAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI.Repository
{
    public class studentRepository : IstudentRepository
    {
        private readonly SchoolDbContext _context;

        public studentRepository(SchoolDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Student> GetStudents()
        {
            var records = _context.Students.ToList();
            return  records;
        }

        public Student Add(Student register)
        {
            _context.Students.Add(register);
            _context.SaveChanges();
            return register;
        }

        public Student GetStudentById(int id)
        {
            return _context.Students.Find(id);
        }

        public Student Update(int id, Student registerChanges)
        {
            var Student = _context.Students.Find(id);

            if(Student != null)
            {
                Student.FirstName = registerChanges.FirstName;
                Student.LastName = registerChanges.LastName;
                Student.Residence = registerChanges.Residence;
                _context.SaveChanges();
            }
            
            return registerChanges;
        }

        public Student UpdatePatch(int id, JsonPatchDocument registerChanges)
        {
            var Student = _context.Students.Find(id);

            if (Student !=null)
            {
                registerChanges.ApplyTo(Student);
                _context.SaveChanges();
            }
            return Student;
        }

        public Student Delete(int id)
        {
            Student student = _context.Students.Find(id);

            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
            }
            return student;
        }
    }
}
