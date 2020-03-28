using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Students.Model.Model;
using Students.Model.Repository;
using Students.Model.Services;

namespace Students.View
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            IStudentDbContext applicationDbContext = new StudentDbContext();
            var studentService = new StudentService(applicationDbContext);
            var courseService = new CourseService(applicationDbContext);
            var studentScoreService=new StudentScoreService(applicationDbContext);
            var applicationController = new ApplicationController(studentService, courseService, studentScoreService);

            SeedDatabase(applicationDbContext);

            applicationController.RunMain();
            //Application.Run(new Form1());
        }

        private static void SeedDatabase(IStudentDbContext dbContext)
        {
            var courseData = dbContext.GetDbSet<Course>();
            if (courseData.SingleOrDefault(c => c.Name == "Mathematics") == default(Course))
            {
                courseData.AddOrUpdate(new Course() { Name = "Mathematics" });
                courseData.AddOrUpdate(new Course() { Name = "Physics" });
                courseData.AddOrUpdate(new Course() { Name = "Literature" });
                courseData.AddOrUpdate(new Course() { Name = "Chemistry" });
                courseData.AddOrUpdate(new Course() { Name = "History" });
                courseData.AddOrUpdate(new Course() { Name = "Sport" });
                courseData.AddOrUpdate(new Course() { Name = "Geometry" });
                courseData.AddOrUpdate(new Course() { Name = "Geography" });
                dbContext.SaveChanges();
            }
        }
    }
}
