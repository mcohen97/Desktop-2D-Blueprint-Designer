using Entities;
using RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Domain;


namespace DataAccess
{
    public class UserRepository : IUserRepository, IRepository<User>
    {

        public bool IsEmpty() {
            bool esVacia;
            using (BlueBuilderDBContext context = new BlueBuilderDBContext())
            {
                esVacia=context.Users.Any();
            }
            return esVacia;
        }

        public void AddUser(Admin anAdmin)
        {
        }

        public void AddUser(Client aClient) {

        }

        public void AddUser(Designer aDesigner) {

        }

        public void Delete(User toDelete)
        {
            using (BlueBuilderDBContext context = new BlueBuilderDBContext())
            {
                UserEntity entity = context.Users.FirstOrDefault(r => r.UserName .Equals(toDelete.UserName));
                context.Users.Remove(entity);
                context.SaveChanges();
            }
        }

        public bool Exists(User toLookup) {
            bool doesExist;

            using (BlueBuilderDBContext context = new BlueBuilderDBContext())
            {
                doesExist = context.Users.Any(u => u.UserName.Equals(toLookup));
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

        public User Get(Guid id)
        {
            using (BlueBuilderDBContext context = new BlueBuilderDBContext())
            {
                return context.Users.FirstOrDefault(a => a.Id == id);
            }
        }


        public User GetUserByUserName(string userName)
        {
            UserEntity record;
            using (BlueBuilderDBContext context = new BlueBuilderDBContext())
            {
                record = context.Users.First(ue => ue.UserName.Equals(userName));
            }
            return record;

        }

        public IEnumerable<User> GetUsersByPermission(int aFeature)
        {
            IQueryable<User> elegibleRecords;
            using (BlueBuilderDBContext context = new BlueBuilderDBContext())
            {
                elegibleRecords = context.Users.Where(ue => ue.Permissions.Contains(aFeature));
            }

            return elegibleRecords;
        }


        public IEnumerable<User> GetAll()
        {
            using (BlueBuilderDBContext context = new BlueBuilderDBContext())
            {
                return context.Users;
            }
        }

        public void Modify(User record)
        {
            using (BlueBuilderDBContext context = new BlueBuilderDBContext())
            {
                context.Entry(record).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
