using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Domain;

namespace DomainRepositoryInterface
{
    public interface IUserRepository
    {
        User Get(User userAsked);
        bool ExistsUserName(string aUserName);

        User GetUserByUserName(string userName);

        ICollection<User> GetUsersByPermission(Permission aFeature);



    }
}
