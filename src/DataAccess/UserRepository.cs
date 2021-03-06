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
using BusinessDataExceptions;
using System.Data.Common;
using System.Data.Entity.Core;

namespace DataAccess
{
    public class UserRepository : IUserRepository, IRepository<User>
    {

        public bool IsEmpty() {
            bool isEmpty;
            try
            {
               isEmpty = TryAskIsEmpty();
            }catch(DbException){
                throw new InaccessibleDataException();
            }
            return isEmpty;
        }

        private bool TryAskIsEmpty() {
            bool isEmpty;
            using (BlueBuilderDBContext context = new BlueBuilderDBContext())
            {
                isEmpty = !context.Users.Any(u => !u.UserName.Equals("admin"));
            }
            return isEmpty;

        }

        public void Add(User aUser)
        {
            
                try
                {
                TryAdd(aUser);
                }
                //existent user in particular.
                catch (DbUpdateException) {
                    throw new UserAlreadyExistsException();
                }
                //the rest of the possible exceptions.
                catch (DbException ) {
                    throw new InaccessibleDataException();
                }
                
                
            
        }

        private void TryAdd(User aUser) {
            using (BlueBuilderDBContext context = new BlueBuilderDBContext())
            {
                UserAndEntityConverter translator = new UserAndEntityConverter();
                UserEntity anEntity = translator.ToEntity(aUser);
                context.Users.Add(anEntity);
                context.SaveChanges();
            }

            }

        public void Delete(User toDelete)
        {
            try {
                TryDelete(toDelete);
            }catch (DbException)
            {
                throw new InaccessibleDataException();
            }

        }

        private void TryDelete(User toDelete) {
            using (BlueBuilderDBContext context = new BlueBuilderDBContext())
            {
                UserEntity entity = context.Users.FirstOrDefault(r => r.UserName.Equals(toDelete.UserName));
                //if it exists, delete it.
                if (entity != null)
                {
                    context.Users.Remove(entity);
                    context.SaveChanges();
                }
            }
        }

        public bool Exists(User toLookup) {
            bool doesExist;
            try {
                doesExist= TryAskIfExists(toLookup.UserName);
            }catch (DbException)
            {
                throw new InaccessibleDataException();
            }
            return doesExist;
        }


        public void Clear() {
            try {
                TryClearUsers();
            }
            catch (DbException)
            {
                throw new InaccessibleDataException();
            }

        }

        private void TryClearUsers() {
            using (BlueBuilderDBContext context = new BlueBuilderDBContext())
            {

                foreach (UserEntity userEnt in context.Users)
                {
                    context.Users.Remove(userEnt);
                }
                AdminEntity putBackAdmin = new AdminEntity() { Name = "admin", Surname = "admin", UserName = "admin", Password = "admin" };

                context.Users.Add(putBackAdmin);
                context.SaveChanges();
            }

        }

        public bool ExistsUserName(string aUserName) {
            bool doesExist;
            try
            {
                doesExist= TryAskIfExists(aUserName);
            }
            catch (DbException)
            {
                throw new InaccessibleDataException();
            }
            return doesExist;
        }
        private bool TryAskIfExists(string aUserName) {
            bool doesExist;

            using (BlueBuilderDBContext context = new BlueBuilderDBContext())
            {
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
            try
            {
                firstToComply=TryGetFirst(aCondition);
            }
            catch (DbException) {
                throw new InaccessibleDataException();
            }
            return firstToComply;
        }

        private User TryGetFirst(Expression<Func<UserEntity, bool>> aCondition) {
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
                    firstToComply = translator.ToUser(firstRecord);
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
            ICollection<User> elegibleUsers;
            try {
                elegibleUsers = TryFilter(aCriteria);
            }
            catch (EntityException) {
                throw new InaccessibleDataException();
            }
            return elegibleUsers;
        }

        private ICollection<User> TryFilter(Expression<Func<UserEntity, bool>> aCriteria) {
            ICollection<User> elegibleUsers = new List<User>();
            using (BlueBuilderDBContext context = new BlueBuilderDBContext())
            {
                UserAndEntityConverter translator = new UserAndEntityConverter();
                IQueryable<UserEntity> elegibleRecords = context.Users.Where(aCriteria);
                foreach (UserEntity record in elegibleRecords)
                {
                    elegibleUsers.Add(translator.ToUser(record));
                }
            }

            return elegibleUsers;
        }

        public void Modify(User modified)
        {
            try
            {
                TryModify(modified);
            }
            catch (EntityException) {
                throw new InaccessibleDataException();
            }
        }

        private void TryModify(User modified) {
            UserAndEntityConverter translator = new UserAndEntityConverter();

            using (BlueBuilderDBContext context = new BlueBuilderDBContext())
            {
                UserEntity record = translator.ToEntity(modified);
                context.Users.Attach(record);
                context.Entry(record).State = EntityState.Modified;
                context.SaveChanges();
            }

        }

    }
}
