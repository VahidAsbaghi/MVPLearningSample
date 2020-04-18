using System;
using System.Collections.Generic;
using Students.Model.Model;
using Students.Model.Repository;

namespace Students.Model.Services
{
    public class StudentService : IStudentService
    {
        private StudentRepository _studentRepository;
        public StudentService(IStudentDbContext studentDbContext)
        {
            _studentRepository = new StudentRepository(studentDbContext);
        }
        public Student AddStudent(Student student)
        {
            var studentEntity=_studentRepository.Add(student);
            if(studentEntity!=null)
                _studentRepository.SaveChanges();
            return studentEntity;
        }

        public bool UpdateStudentInfo(Student student)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetAll()
        {
            return _studentRepository.GetAll();
        }

        public Student GetStudent(int studentId)
        {
            return _studentRepository.FindById(studentId);
        }
    }
}