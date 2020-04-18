using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Students.Model.Annotations;

namespace Students.Model.Model
{
    public class Student:BaseModel,ICloneable
    {
        public Student()
        {
            StudentCourses=new HashSet<StudentCourse>();
        }
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false,ErrorMessage = "Name Field is Required")]
        public string Name { get; set; }
        public string LastName { get; set; }
        [NotMapped]
        public string FullName => Name + " " + LastName;
        public string StudentNumber { get; set; }
        public string Mobile { get; set; }
        public virtual ICollection<StudentCourse> StudentCourses { get; set; }

        public object Clone()
        {
            return new Student()
            {
                Id = this.Id,
                LastName = this.LastName,
                Name = this.Name,
                Mobile = this.Mobile,
                StudentNumber = this.StudentNumber,
                StudentCourses = this.StudentCourses
            };
        }
    }
}
