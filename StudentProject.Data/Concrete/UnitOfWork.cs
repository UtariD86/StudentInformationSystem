using StudentProject.Data.Abstract;
using StudentProject.Data.Concrete.EntityFramework.Contexts;
using StudentProject.Data.Concrete.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProject.Data.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StudentProjectContext _context;
        private EfStudentRepository _studentrepository;
        private EfLessonRepository _lessonrepository;

        public UnitOfWork(StudentProjectContext context)
        {
            _context = context;
        }

        public ILessonRepository Lessons => _lessonrepository ?? new EfLessonRepository(_context);

        public IStudentRepository Students => _studentrepository ?? new EfStudentRepository(_context);

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
