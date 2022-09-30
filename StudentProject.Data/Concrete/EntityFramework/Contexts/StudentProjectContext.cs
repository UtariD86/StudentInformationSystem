using Microsoft.EntityFrameworkCore;
using StudentProject.Data.Concrete.EntityFramework.Mappings;
using StudentProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProject.Data.Concrete.EntityFramework.Contexts
{
    public class StudentProjectContext:DbContext
    {
        public DbSet<Lesson> Lessons { get; set; }

        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=StudentProjectV1;Trusted_Connection=True;Connect Timeout=30;MultipleActiveResultSets=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LessonMap());
            modelBuilder.ApplyConfiguration(new StudentMap());
        }
    }
}
