using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Domain;

namespace UserRepositoryInterface
{
    public interface IUserRepository
    {
        bool ExistsUserName(string aUserName);

        User GetUserByUserName(string userName);

        ICollection<User> GetUsersByPermission(Permission aFeature);



    }
}
