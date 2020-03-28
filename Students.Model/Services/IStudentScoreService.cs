using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Students.Model.Model;

namespace Students.Model.Services
{
    public interface IStudentScoreService
    {
        void Add(StudentCourse studentCourse);
    }
}
