using Entities;
using RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
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

        public void Add(User aUser)
        {
            using (BlueBuilderDBContext context = new BlueBuilderDBContext())
            {
                DomainAndEntityConverter translator = new DomainAndEntityConverter();
                UserEntity anEntity = translator.toEntity(aUser);
                context.Users.Add(anEntity);
                context.SaveChanges();
            }
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
            return SelectFirstOrDefault(a => a.Id.Equals(id));
            /*User queryUser;
            using (BlueBuilderDBContext context = new BlueBuilderDBContext())
            {
                DomainAndEntityConverter translator = new DomainAndEntityConverter();
                UserEntity query = context.Users.FirstOrDefault(a => a.Id.Equals(id));
                queryUser = translator.toUser(query);
            }
            return queryUser;*/
        }

        public User GetUserByUserName(string userName)
        {
            return SelectFirstOrDefault(u => u.UserName.Equals(userName));
            /*User queryUser;
            using (BlueBuilderDBContext context = new BlueBuilderDBContext())
            {
                DomainAndEntityConverter translator = new DomainAndEntityConverter();
                UserEntity query = context.Users.FirstOrDefault(a => a.UserName.Equals(userName));
                queryUser = translator.toUser(query);
            }
            return queryUser;*/

        }
        public User Get(User userAsked)
        {
            return GetUserByUserName(userAsked.UserName);
        }

        private User SelectFirstOrDefault(Expression<Func<UserEntity, bool>> aCondition) {
            User firstToComply;
            using (BlueBuilderDBContext context = new BlueBuilderDBContext())
            {
                DomainAndEntityConverter translator = new DomainAndEntityConverter();
                UserEntity firstRecord = context.Users.FirstOrDefault(aCondition);
                firstToComply = translator.toUser(firstRecord);
            }

            return firstToComply;
        }

        public ICollection<User> GetUsersByPermission(int aFeature)
        {
            return SelectByCriteria(ue => ue.Permissions.Contains(aFeature));
            /*IEnumerable<User> elegibleUsers;
            using (BlueBuilderDBContext context = new BlueBuilderDBContext())
            {
                DomainAndEntityConverter translator = new DomainAndEntityConverter();
                IQueryable<UserEntity> elegibleRecords = context.Users.Where(ue => ue.Permissions.Contains(aFeature));
                elegibleUsers = elegibleRecords.Select(r => translator.toUser(r));
            }

            return elegibleUsers;*/
        }


        public ICollection<User> GetAll()
        {
            return SelectByCriteria(u=> true);
            /*IEnumerable<User> elegibleUsers;
            using (BlueBuilderDBContext context = new BlueBuilderDBContext())
            {
                DomainAndEntityConverter translator = new DomainAndEntityConverter();
                IQueryable<UserEntity> elegibleRecords = context.Users;
                elegibleUsers = elegibleRecords.Select(r => translator.toUser(r));
            }

            return elegibleUsers;*/
        }

        private ICollection<User> SelectByCriteria(Expression<Func<UserEntity, bool>> aCriteria) {
            ICollection<User> elegibleUsers;
            using (BlueBuilderDBContext context = new BlueBuilderDBContext())
            {
                DomainAndEntityConverter translator = new DomainAndEntityConverter();
                IQueryable<UserEntity> elegibleRecords = context.Users.Where(aCriteria);
                elegibleUsers = elegibleRecords.Select(r => translator.toUser(r)).ToList();
            }

            return elegibleUsers;
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
