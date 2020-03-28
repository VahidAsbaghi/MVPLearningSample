using System;
using System.Collections.Generic;
using Students.Model.Model;
using Students.Model.Repository;

namespace Students.Model.Services
{
    public class CourseService : ICourseService
    {
        private readonly CourseRepository _courseRepository;
        public CourseService(IStudentDbContext studentDbContext)
        {
            _courseRepository=new CourseRepository(studentDbContext);
        }
        public IEnumerable<Course> GetAllCourses()
        {
           return _courseRepository.GetAll();
        }

        public Course GetCourse(string courseName)
        {
            return _courseRepository.Get(course => course.Name == courseName);
        }
    }
}