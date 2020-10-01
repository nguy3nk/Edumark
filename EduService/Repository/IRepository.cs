using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EduService.Repository
{
    interface IRepository<T> where T : class
    {
        // Get All data of TEntity
        IEnumerable<T> GetAll();

        // Get All data of TEntity satisfy the conditions (predicate: conditional expression )
        IEnumerable<T> GetBy(Func<T, bool> predicate);

        // Get 1 TEntity by Id
        T Get(object id);

        // Get 1 TEntity satisfy the conditions
        T SingleBy(Func<T, bool> predicate);
        // Add 1 TEntity
        bool Add(T entity);
        // Add multi entities
        bool AddRange(IEnumerable<T> entities);
        bool Edit(T entity);
        bool Remove(object id);
        bool Remove(T entity);

        // Remove multi entities
        bool RemoveRange(IEnumerable<T> entities);

        bool Update(T entity);

        T GetBy1(Expression<Func<T, bool>> where);
    }
}
