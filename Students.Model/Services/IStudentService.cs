using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Students.Model.Model;

namespace Students.Model.Services
{
    public interface IStudentService
    {
        Student AddStudent(Student student);
        bool UpdateStudentInfo(Student student);
        IEnumerable<Student> GetAll();
        Student GetStudent(string studentNumber);
    }
}
