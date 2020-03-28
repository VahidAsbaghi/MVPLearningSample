using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Students.Model.Model;

namespace Students.Model.Repository
{
    public class StudentDbContext:DbContext,IStudentDbContext
    {
        /// <exception cref="UnauthorizedAccessException">The caller does not have the required permission.-or- 
        ///               <paramref name="path" /> specified a read-only file or directory. </exception>
        /// <exception cref="ArgumentException">
        ///               <paramref name="path" /> is a zero-length string, contains only white space, or contains one or more invalid characters as defined by <see cref="F:System.IO.Path.InvalidPathChars" />. </exception>
        /// <exception cref="NotSupportedException">
        ///               <paramref name="path" /> is in an invalid format. </exception>
        /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters. </exception>
        /// <exception cref="DirectoryNotFoundException">The specified path is invalid, (for example, it is on an unmapped drive). </exception>
        

       

        public StudentDbContext() : base("StudentsDb")
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }


        public IDbSet<T> GetDbSet<T>() where T : class
        {
            return Set<T>();
        }

        /// <exception cref="DbUpdateConcurrencyException">
        ///             A database command did not affect the expected number of rows. This usually indicates an optimistic 
        ///             concurrency violation; that is, a row has been changed in the database since it was queried.
        ///             </exception>
        /// <exception cref="DbUpdateException">An error occurred sending updates to the database.</exception>
        public new int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Debug.Write($"Entity of type \"{eve.Entry.Entity.GetType().Name}\" in state \"{eve.Entry.State}\" has the following validation errors:");
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Debug.Write($"- Property: \"{ve.PropertyName}\", Error: \"{ve.ErrorMessage}\"");
                    }
                }
                throw;
            }
        }
    }
}
