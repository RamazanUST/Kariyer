using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Kariyer.Repository.Fabric
{
    public interface ICrud<T> where T : class
    {

        T FindById(Guid id);
        T FindBySelect(Expression<Func<T, bool>> filter);
        bool FindByAny(Expression<Func<T, bool>> filter);
        IEnumerable<T> List(Expression<Func<T, bool>> filter = null);
        IEnumerable<TResult> List<TResult>(Expression<Func<T, TResult>> selector, Expression<Func<T, bool>> filter = null);
        int Count(Expression<Func<T, bool>> filter = null);
        void Insert(T entity);
        void Update(T entity);
        void Delete(Guid Id);
        void Delete(T entity);
    }
}
