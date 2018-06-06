using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Domain;

namespace RepositoryInterface
{
    public interface IUserRepository
    {
        bool ExistsUserName(string aUserName);

        User GetUserByUserName(string userName);

        IEnumerable<User> GetUsersByPermission(int aFeature);



    }
}
