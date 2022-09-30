using Microsoft.EntityFrameworkCore;
using StudentProject.Data.Abstract;
using StudentProject.Entities.Concrete;
using StudentProject.Shared.Data.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProject.Data.Concrete.EntityFramework.Repositories
{
    public class EfLessonRepository : EntityRepositoryBase<Lesson>, ILessonRepository
    {
        public EfLessonRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
