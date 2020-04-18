using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Students.Model.Model;
using Students.Presenter.ViewModel;

namespace Students.Presenter
{
    public class ViewMainPresenter:IViewMainPresenter
    {
        private readonly IViewMain _view;
        private readonly IApplicationController _applicationController;

        public ViewMainPresenter(IViewMain viewMain,IApplicationController applicationController)
        {
            _view = viewMain;
            _applicationController = applicationController;
            _view.Presenter = this;
        }
        public IViewMain View
        {
            get { return _view; }
        }

        public void Run()
        {
            _view.Students = _applicationController.StudentService.GetAll();
            _view.Courses = _applicationController.CourseService.GetAllCourses();
            _view.Run();
        }

        public Student AddStudent(Student student)
        {
            return _applicationController.StudentService.AddStudent(student);
        }

        public void AddScore(StudentScoreViewModel studentScore)
        {
            var course=_applicationController.CourseService.GetCourse(studentScore.CourseName);
            var student = _applicationController.StudentService.GetStudent(studentScore.StudentId);
            var studentCourse = new StudentCourse
            {
                Student = student,
                Course = course,
                Score = studentScore.Score
            };
            _applicationController.StudentScoreService.Add(studentCourse);
        }
    }
}
