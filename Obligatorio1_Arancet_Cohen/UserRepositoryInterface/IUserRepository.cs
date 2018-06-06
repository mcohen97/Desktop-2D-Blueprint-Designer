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
        void AddUser(Admin anAdmin);

        void AddUser(Client aClient);

        void AddUser(Designer aDesigner);

        bool ExistsUserName(string aUserName);

        User GetUserByUserName(string userName);

        IEnumerable<User> GetUsersByPermission(int aFeature);



    }
}
