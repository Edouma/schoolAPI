using SchoolAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI.Repository
{
    public interface IstudentRepository
    {
        IEnumerable<Student> GetStudents();
        Student Add(Student register);
        Student GetStudentById(int id);
        Student Update(int id, Student registerChanges);
        Student Delete(int id);

    }
}
