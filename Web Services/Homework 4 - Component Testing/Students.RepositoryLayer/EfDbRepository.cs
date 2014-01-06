using System;
using System.Linq;
using System.Data.Entity;

namespace Students.RepositoryLayer
{
    public class EfDbRepository<T> : IRepository<T> where  T:class
     {
        private readonly DbContext context;
        private readonly DbSet<T> entitySet;

        public EfDbRepository(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentException("An instance of DbContext is required to use this repository.", "context");
            }

            this.context = context;
            this.entitySet = this.context.Set<T>();
        }

        public T Add(T entity)
        {
            this.entitySet.Add(entity);
            this.context.SaveChanges();
            return entity;
        }

        public T Update(int id, T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            var entity = this.entitySet.Find(id);
            if (entity != null)
            {
                this.entitySet.Remove(entity);
                this.context.SaveChanges();
            }
        }

        public T Get(int id)
        {
            return this.entitySet.Find(id);
        }

        public IQueryable<T> All()
        {
            return this.entitySet;
        }

        public IQueryable<T> Find(System.Linq.Expressions.Expression<Func<T, int, bool>> predicate)
        {
            return this.entitySet.Where(predicate);
        }
    }
}
