using Entities;
using RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccess
{
    public class UserRepository : IRepository<UserEntity>
    {
        public void Add(UserEntity entity)
        {
            using (BlueBuilderDBContext context = new BlueBuilderDBContext())
            {
                context.Users.Add(entity);
                context.SaveChanges();
            }
        }

        public void Delete(UserEntity entity)
        {
            using (BlueBuilderDBContext context = new BlueBuilderDBContext())
            {
                context.Users.Remove(entity);
                context.SaveChanges();
            }
        }

        public UserEntity Get(Guid id)
        {
            using (BlueBuilderDBContext context = new BlueBuilderDBContext())
            {
                return context.Users.FirstOrDefault(a => a.Id == id);
            }
        }

        public IEnumerable<UserEntity> GetAll()
        {
            using (BlueBuilderDBContext context = new BlueBuilderDBContext())
            {
                return context.Users;
            }
        }

        public void Modify(UserEntity entity)
        {
            using (BlueBuilderDBContext context = new BlueBuilderDBContext())
            {
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
