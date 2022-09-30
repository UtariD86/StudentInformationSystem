using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProject.Data.Abstract
{
    public interface IUnitOfWork:IAsyncDisposable
    {
        ILessonRepository Lessons { get; }

        IStudentRepository Students { get; }

        Task<int> SaveAsync();
    }
}
