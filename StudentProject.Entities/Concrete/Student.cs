using StudentProject.Entities.Abstract;
using StudentProject.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProject.Entities.Concrete
{
    public class Student:EntityBase,IEntity
    {
        public string Name { get; set; }

        public string Lastname { get; set; }

        public string Number { get; set; }
    }
}
