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
    public class LessonMap : IEntityTypeConfiguration<Lesson>
    {
        public void Configure(EntityTypeBuilder<Lesson> builder)
        {
            builder.HasKey(l => l.Id);
            builder.Property(l => l.Name).IsRequired();
            builder.Property(l => l.Name).HasMaxLength(50);
            builder.Property(l =>l.Credit).IsRequired();
            builder.Property(l => l.CreatedByName).IsRequired();
            builder.Property(l => l.CreatedByName).HasMaxLength(50);
            builder.Property(l => l.ModifiedByName).IsRequired();
            builder.Property(l => l.ModifiedByName).HasMaxLength(50);
            builder.Property(l => l.CreatedDate).IsRequired();
            builder.Property(l => l.ModifiedDate).IsRequired();
            builder.Property(l => l.IsActive).IsRequired();
            builder.Property(l => l.IsDeleted).IsRequired();
            builder.Property(l => l.Note).HasMaxLength(500);
            builder.ToTable("Lessons");

            builder.HasData(
                new Lesson
                {
                    Id = 1,
                    Name = "Matematik",
                    Credit = 6
                },
                new Lesson
                {
                    Id=2,
                    Name = "Fizik 1",
                    Credit = 5
                }
            );


        }
    }
}
