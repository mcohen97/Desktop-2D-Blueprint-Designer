using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryInterface
{
    public interface IRepository<T>
    {
        void Add(T entity);

        void Delete(T entity);

        void Modify(T entity);

        T Get(Guid id);

        IEnumerable<T> GetAll();
    }
}
