using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Model.Repository
{
    public interface IStudentDbContext
    {
        IDbSet<T> GetDbSet<T>() where T : class;
        int SaveChanges();
    }
}
