using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryInterface
{
    public interface IRepository<T>
    {
        bool IsEmpty();

        void Delete(T entity);

        bool Exists(T record);
        void Clear();

        void Modify(T entity);

        T Get(Guid id);

        IEnumerable<T> GetAll();
    }
}
