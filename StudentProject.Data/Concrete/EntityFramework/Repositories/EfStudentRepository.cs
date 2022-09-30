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
    public class EfStudentRepository : EntityRepositoryBase<Student>, IStudentRepository
    {
        public EfStudentRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
