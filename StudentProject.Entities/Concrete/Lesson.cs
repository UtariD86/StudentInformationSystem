using StudentProject.Entities.Abstract;
using StudentProject.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProject.Entities.Concrete
{
    public class Lesson:EntityBase,IEntity
    {
        public string Name { get; set; }
        
        public int Credit { get; set; }
    }
}
