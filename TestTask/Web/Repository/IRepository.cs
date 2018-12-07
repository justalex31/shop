using System;
using System.Collections.Generic;

namespace Web.Repository
{
    interface IRepository<T> where T : class
    {
        void Add(T entity);

        void AddRange(IEnumerable<T> entities);

        T Get(Guid id);

        IEnumerable<T> GetAll();

        void Update(T entity);

        void Delete(T entity);
    }
}
