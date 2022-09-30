using StudentProject.Entities.Concrete;
using StudentProject.Shared.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProject.Data.Abstract
{
    public interface ILessonRepository:IEntityRepository<Lesson>
    {
    }
}
