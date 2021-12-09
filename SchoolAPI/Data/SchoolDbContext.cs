using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI.Data
{
    public class SchoolDbContext : IdentityDbContext<ApplicationUser>
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options): base(options)
        {

        }
       public  DbSet<Student> Students { get; set; }
       public DbSet<Course> Courses { get; set; }
       public DbSet<Fee> Fees { get; set; }
    }
}
