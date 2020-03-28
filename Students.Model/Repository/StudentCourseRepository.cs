using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Students.Model.Model;

namespace Students.Model.Repository
{
    public class StudentCourseRepository:Repository<StudentCourse>
    {
        public StudentCourseRepository(IStudentDbContext studentDbContext) : base(studentDbContext)
        {
        }
    }
}
