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
using DomainRepositoryInterface;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using DataAccessExceptions;

namespace DataAccess
{
    public class UserRepository : IUserRepository, IRepository<User>
    {

        public bool IsEmpty() {
            bool isEmpty;
            using (BlueBuilderDBContext context = new BlueBuilderDBContext())
            {
                isEmpty=!context.Users.Any(u=> !u.UserName.Equals("admin"));
            }
            return isEmpty;
        }

        public void Add(User aUser)
        {
            using (BlueBuilderDBContext context = new BlueBuilderDBContext())
            {
                    UserAndEntityConverter translator = new UserAndEntityConverter();
                    UserEntity anEntity = translator.toEntity(aUser);
                try
                {
                    context.Users.Add(anEntity);
                    context.SaveChanges();
                }
                catch (DbUpdateException) {
                    throw new UserAlreadyExistsException();
                }
                
                
            }
        }

        public void Delete(User toDelete)
        {
            using (BlueBuilderDBContext context = new BlueBuilderDBContext())
            {
                UserEntity entity = context.Users.FirstOrDefault(r => r.UserName .Equals(toDelete.UserName));
                if (entity != null)
                {
                    context.Users.Remove(entity);
                    context.SaveChanges();
                }
            }
        }

        public bool Exists(User toLookup) {
            bool doesExist;

            using (BlueBuilderDBContext context = new BlueBuilderDBContext())
            {
                doesExist = context.Users.Any(u => u.UserName.Equals(toLookup.UserName));
            }

            return doesExist;
        }

        public void Clear() {
            using (BlueBuilderDBContext context = new BlueBuilderDBContext())
            {
                foreach (BlueprintEntity bpEnt in context.Blueprints) {
                    context.Blueprints.Remove(bpEnt);
                }
                foreach (UserEntity userEnt in context.Users)
                {
                    context.Users.Remove(userEnt);
                }
                AdminEntity putBackAdmin = new AdminEntity() { Name = "admin", Surname="admin", UserName= "admin", Password="admin"};

                context.Users.Add(putBackAdmin);
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
        }

        public User GetUserByUserName(string userName)
        {
            return SelectFirstOrDefault(u => u.UserName.Equals(userName));

        }
        public User Get(User userAsked)
        {
            return GetUserByUserName(userAsked.UserName);
        }

        private User SelectFirstOrDefault(Expression<Func<UserEntity, bool>> aCondition) {
            User firstToComply;
            using (BlueBuilderDBContext context = new BlueBuilderDBContext())
            {
                UserAndEntityConverter translator = new UserAndEntityConverter();
                UserEntity firstRecord = context.Users.FirstOrDefault(aCondition);

                if (firstRecord == null)
                {
                    throw new UserNotFoundException();
                }
                else
                {
                    firstToComply = translator.toUser(firstRecord);
                }
            }

            return firstToComply;
        }

        public ICollection<User> GetUsersByPermission(Permission aFeature)
        {
            return GetAll().Where(u => u.HasPermission(aFeature)).ToList();

        }


        public ICollection<User> GetAll()
        {
            return SelectByCriteria(u=> true);
        }

        private ICollection<User> SelectByCriteria(Expression<Func<UserEntity, bool>> aCriteria) {
            ICollection<User> elegibleUsers = new List<User>();
            using (BlueBuilderDBContext context = new BlueBuilderDBContext())
            {
                UserAndEntityConverter translator = new UserAndEntityConverter();
                IQueryable<UserEntity> elegibleRecords = context.Users.Where(aCriteria);
                foreach (UserEntity record in elegibleRecords) {
                    elegibleUsers.Add(translator.toUser(record));
                }
            }

            return elegibleUsers;
        }

        public void Modify(User modified)
        {
            UserAndEntityConverter translator = new UserAndEntityConverter();

            using (BlueBuilderDBContext context = new BlueBuilderDBContext())
            {
                UserEntity record = translator.toEntity(modified);
                context.Users.Attach(record);
                context.Entry(record).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

    }
}
