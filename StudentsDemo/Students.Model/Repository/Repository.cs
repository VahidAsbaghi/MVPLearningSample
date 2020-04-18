using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Students.Model.Model;

namespace Students.Model.Repository
{
    public class Repository<T> : IRepository<T> where T:class 
    {
        private readonly IStudentDbContext _studentDbContext;
        private readonly IDbSet<T> _set;

        public Repository(IStudentDbContext studentDbContext)
        {
            _studentDbContext = studentDbContext;
            _set = studentDbContext.GetDbSet<T>();
        }


        public T Add(T entity)
        {
            return _set.Add(entity);
        }

        public void Delete(T entity)
        {
            _set.Remove(entity);
        }

        public T Get(Expression<Func<T,bool>> predicate)
        {
            return _set.Single(predicate);
        }

        public IEnumerable<T> GetAll()
        {
            return _set.AsQueryable();
        }

        public T Update(T entity)
        {
            return _set.Attach(entity);
        }

        public T FindById(int id)
        {
            return _set.Find(id);
        }

        public void SaveChanges()
        {
            _studentDbContext.SaveChanges();
        }
    }
}
