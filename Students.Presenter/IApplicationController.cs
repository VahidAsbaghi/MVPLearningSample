using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Students.Model.Services;

namespace Students.Presenter
{
    public interface IApplicationController
    {
        void RunMain();
        IStudentService StudentService { get; }
        ICourseService CourseService { get; }
        IStudentScoreService StudentScoreService { get; }
    }
}
