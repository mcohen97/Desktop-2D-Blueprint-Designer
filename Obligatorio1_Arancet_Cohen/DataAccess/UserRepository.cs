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

        public bool IsEmpty() {
            bool esVacia;
            using (BlueBuilderDBContext context = new BlueBuilderDBContext())
            {
                esVacia=context.Users.Any();
            }
            return esVacia;
        }

        public void Add(UserEntity record)
        {
            using (BlueBuilderDBContext context = new BlueBuilderDBContext())
            {
                context.Users.Add(record);
                context.SaveChanges();
            }
        }

        public void Delete(UserEntity record)
        {
            using (BlueBuilderDBContext context = new BlueBuilderDBContext())
            {
                context.Users.Remove(record);
                context.SaveChanges();
            }
        }

        public bool Exists(UserEntity record) {
            bool doesExist;

            using (BlueBuilderDBContext context = new BlueBuilderDBContext())
            {
                doesExist=context.Users.Contains(record);
            }

            return doesExist;
        }

        public void Clear() {
            using (BlueBuilderDBContext context = new BlueBuilderDBContext())
            {
                foreach (var userEnt in context.Users)
                {
                    context.Users.Remove(userEnt);
                }
                context.SaveChanges();
            }

        }

        public bool ExistsUserName(string aUserName) {
            bool doesExist;

            using (BlueBuilderDBContext context = new BlueBuilderDBContext()) {
                doesExist = context.Users.Any(u => u.UserName.Equals(aUserName));
            }

            return doesExist;
        }

        public UserEntity Get(Guid id)
        {
            using (BlueBuilderDBContext context = new BlueBuilderDBContext())
            {
                return context.Users.FirstOrDefault(a => a.Id == id);
            }
        }


        public UserEntity GetUserByUserName(string userName)
        {
            UserEntity record;
            using (BlueBuilderDBContext context = new BlueBuilderDBContext())
            {
                record = context.Users.First(ue => ue.UserName.Equals(userName));
            }
            return record;

        }

        public IEnumerable<UserEntity> GetUsersByPermission(int aFeature)
        {
            IQueryable<UserEntity> elegibleRecords;
            using (BlueBuilderDBContext context = new BlueBuilderDBContext())
            {
                elegibleRecords = context.Users.Where(ue => ue.Permissions.Contains(aFeature));
            }

            return elegibleRecords;
        }


        public IEnumerable<UserEntity> GetAll()
        {
            using (BlueBuilderDBContext context = new BlueBuilderDBContext())
            {
                return context.Users;
            }
        }

        public void Modify(UserEntity record)
        {
            using (BlueBuilderDBContext context = new BlueBuilderDBContext())
            {
                context.Entry(record).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
