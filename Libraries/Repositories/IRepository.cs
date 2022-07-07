using System;
using System.Collections.Generic;
using System.Text;

namespace Libraries.Repositories
{
    public interface IRepository<T>
    {
        void Create(T entity);

        T Read(int id);

        void Update(T entity, int id);

        void Delete(int id);

        IEnumerable<T> GetAll();
    }
}
