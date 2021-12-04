using Microsoft.AspNetCore.JsonPatch;
using SchoolAPI.Data;
using System.Collections.Generic;

namespace SchoolAPI.Repository
{
    public interface IstudentRepository
    {
        IEnumerable<Student> GetStudents();
        Student Add(Student register);
        Student GetStudentById(int id);
        Student Update(int id, Student registerChanges);
        Student UpdatePatch(int id, JsonPatchDocument registerChanges);
        Student Delete(int id);

    }
}
