using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Students.Model.Services;
using Students.Presenter;

namespace Students.View
{
    public class ApplicationController:IApplicationController
    {
        public ApplicationController(IStudentService studentService,ICourseService courseService,IStudentScoreService studentScoreService)
        {
            StudentService = studentService;
            CourseService = courseService;
            StudentScoreService = studentScoreService;
        }

        public ICourseService CourseService { get;}
        public IStudentScoreService StudentScoreService { get; }
        public IStudentService StudentService { get; }


        public void RunMain()
        {
            using (var view=new ViewMain())
            {
                var presenter=new ViewMainPresenter(view,this);
                presenter.Run();
            }
        }



    }
}
