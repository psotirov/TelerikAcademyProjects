using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Students.RepositoryLayer
{
    public class FakeDbRepository<T> : IRepository<T> where T : class
    {
        public IList<T> entities = new List<T>();

        public T Add(T entity)
        {
            this.entities.Add(entity);
            return entity;
        }
        public T Get(int id)
        {
            return this.entities[id-1];
        }

        public IQueryable<T> All()
        {
            return this.entities.AsQueryable();
        }

        public T Update(int id, T entity)
        {
            this.entities[id] = entity;
            return entity;
        }

        public void Delete(int id)
        {
            // do nothing - fake delete method
        }

        public IQueryable<T> Find(Expression<Func<T, int, bool>> predicate)
        {
            return this.entities.Where(predicate.Compile()).AsQueryable();
        }
    }
}
