using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProject.Data.Concrete.EntityFramework.Mappings
{
    public class StudentMap : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Name).IsRequired();
            builder.Property(s => s.Name).HasMaxLength(50);
            builder.Property(s => s.Lastname).IsRequired();
            builder.Property(s => s.Lastname).HasMaxLength(50);
            builder.Property(s => s.Number).IsRequired();
            builder.Property(s => s.Number).HasMaxLength(25);
            builder.Property(s => s.CreatedByName).IsRequired();
            builder.Property(s => s.CreatedByName).HasMaxLength(50);
            builder.Property(s => s.ModifiedByName).IsRequired();
            builder.Property(s => s.ModifiedByName).HasMaxLength(50);
            builder.Property(s => s.CreatedDate).IsRequired();
            builder.Property(s => s.ModifiedDate).IsRequired();
            builder.Property(s => s.IsActive).IsRequired();
            builder.Property(s => s.IsDeleted).IsRequired();
            builder.Property(s => s.Note).HasMaxLength(500);
            builder.ToTable("Students");

            builder.HasData(
                new Student
                {
                    Id = 1,
                    Name = "Ahmet",
                    Lastname = "Çiftçi",
                    Number = "211213100"
                },
                new Student
                {
                    Id = 2,
                    Name = "Mehmet",
                    Lastname = "Göksu",
                    Number = "212705001"
                }
            );
        }
    }
}
