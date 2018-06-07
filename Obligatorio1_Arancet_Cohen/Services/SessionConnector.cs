using Logic.Exceptions;
using Logic.Domain;
using DataAccess;
using RepositoryInterface;
using UserRepositoryInterface;

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
            return new Session(userLogging);
        }
    }
}