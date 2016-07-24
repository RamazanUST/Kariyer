using Kariyer.Entity;
using Kariyer.Repository.Fabric;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Kariyer.Repository
{
    public class Generic<T> : ICrud<T> where T : class
    {
        private KariyerEntities _context;
        private DbSet<T> _dbSet;

        public Generic(KariyerEntities Context)
        {
            _context = Context;
            _dbSet = _context.Set<T>();
        }

        public T FindById(Guid id)
        {
            return _dbSet.Find(id);
        }

        public T FindBySelect(Expression<Func<T, bool>> filter)
        {
            return _dbSet.Where(filter).FirstOrDefault();
        }

        public bool FindByAny(Expression<Func<T, bool>> filter)
        {
            return _dbSet.Any(filter);
        }

        public IEnumerable<T> List(Expression<Func<T, bool>> filter = null)
        {
            if (filter != null)
            {
                return _dbSet.Where(filter);
            }

            return _dbSet;
        }

        public IEnumerable<TResult> List<TResult>(Expression<Func<T, TResult>> selector, Expression<Func<T, bool>> filter = null)
        {
            if (filter != null)
            {
                return _dbSet.Where(filter).Select(selector);
            }

            return _dbSet.Select(selector);
        }

        public int Count(Expression<Func<T, bool>> filter = null)
        {
            if (filter != null)
            {
                return _dbSet.Count(filter);
            }

            return _dbSet.Count();
        }

        public void Insert(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(Guid id)
        {
            T entityToDelete = _dbSet.Find(id);
            this.Delete(entityToDelete);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }
    }
}
