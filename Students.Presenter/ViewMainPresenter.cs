using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Students.Model.Model;
using Students.Presenter.ViewModel;

namespace Students.Presenter
{
    public class ViewMainPresenter:IViewMainPresenter
    {
        private readonly IViewMain _view;
        private readonly IApplicationController _applicationController;
        private readonly IMapper _mapper;

        public ViewMainPresenter(IViewMain viewMain,IApplicationController applicationController)
        {
            _view = viewMain;
            _applicationController = applicationController;
            _view.Presenter = this;
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Student, StudentViewModel>();
                cfg.CreateMap<StudentViewModel, Student>();
            });
            
            _mapper = configuration.CreateMapper();
            
        }
        public IViewMain View
        {
            get { return _view; }
        }

        public void Run()
        {
            _view.Students =
                _mapper.Map<IEnumerable<Student>, List<StudentViewModel>>(_applicationController.StudentService
                    .GetAll());
            _view.Courses = _applicationController.CourseService.GetAllCourses();
            _view.Run();
        }

        public bool AddStudent(StudentViewModel student)
        {
            var studentModel = _mapper.Map<StudentViewModel, Student>(student);// new Student();
            //studentModel.Name = student.Name;
            //studentModel.LastName = student.LastName;
            //studentModel.Mobile = student.Mobile;
            //studentModel.StudentNumber = student.StudentNumber;
            _applicationController.StudentService.AddStudent(studentModel);
            return true;
        }

        public void AddScore(StudentScoreViewModel studentScore)
        {
            var course=_applicationController.CourseService.GetCourse(studentScore.CourseName);
            var student = _applicationController.StudentService.GetStudent(studentScore.StudentNumber);
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
