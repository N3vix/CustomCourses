using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomCursesLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace DbWebApi.Model
{
    public class CoursesContext : DbContext
    {
        public CoursesContext(DbContextOptions<CoursesContext> options)
            : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
    }
}
