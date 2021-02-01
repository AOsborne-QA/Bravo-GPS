using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Radar.Library.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> FindAll();
        IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression);
        T Create(T entity);
        T Update(T entity);
        void Delete(T entity);

    }
}
