using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Model.Model
{
    public class Course
    {
        public Course()
        {
            StudentCourses=new HashSet<StudentCourse>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<StudentCourse> StudentCourses { get; set; }
    }
}
