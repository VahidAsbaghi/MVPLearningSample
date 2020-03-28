using System;
using Students.Model.Model;
using Students.Model.Repository;

namespace Students.Model.Services
{
    public class StudentScoreService : IStudentScoreService
    {
        private readonly StudentCourseRepository _studentCourseRepository;

        public StudentScoreService(IStudentDbContext studentDbContext)
        {
            _studentCourseRepository = new StudentCourseRepository(studentDbContext);
        }

        public void Add(StudentCourse studentCourse)
        {
            _studentCourseRepository.Add(studentCourse);
            _studentCourseRepository.SaveChanges();
        }
    }
}