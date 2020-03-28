using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Students.Model.Model;

namespace Students.Model.Repository
{
    public class StudentRepository:Repository<Student>
    {
        public StudentRepository(IStudentDbContext studentDbContext) : base(studentDbContext)
        {
        }
    }
}
