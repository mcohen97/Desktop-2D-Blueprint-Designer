using Logic.Domain;
using DataAccess;
using RepositoryInterface;
using DomainRepositoryInterface;
using ServicesExceptions;

namespace Services
{
    public class SessionConnector
    {
        public Session LogIn(string userName, string password)
        {
            IUserRepository userStorage = new UserRepository();
            User userLogging = userStorage.GetUserByUserName(userName);
            if (userLogging.Password != password)
            {
                throw new WrongPasswordException();
            }
            Session created = new Session(userLogging);
            ((IRepository<User>)userStorage).Modify(userLogging);
            return created;
        }
    }
}