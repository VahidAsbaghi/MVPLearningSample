using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Students.Model.Repository
{
    public interface IRepository<T>
    {
        T Add(T entity);
        void Delete(T entity);
        T Get(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetAll();
        T Update(T entity);
        T FindById(int id);
        void SaveChanges();
    }
}
