using Microsoft.AspNetCore.JsonPatch;
using SchoolAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI.Repository
{
   public  interface ICourseRepository
    {
        IEnumerable<Course> GetAllCourses();
        Course Add(Course register);
        Course GetCourseById(int id);
        Course Update(int id, Course registerChanges);
        Course UpdatePatch(int id, JsonPatchDocument registerChanges);
        Course Delete(int id);
    }
}
