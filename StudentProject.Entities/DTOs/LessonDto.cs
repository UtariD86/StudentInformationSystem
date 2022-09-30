using StudentProject.Entities.Concrete;
using StudentProject.Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProject.Entities.DTOs
{
    public class LessonDto : DtoGetBase
    {
        public Lesson Lesson { get; set; }
    }
}
