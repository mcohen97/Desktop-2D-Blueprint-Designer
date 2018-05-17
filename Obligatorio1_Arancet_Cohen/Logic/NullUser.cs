using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Domain
{
    class NullUser:User
    {
        public NullUser()
        {
            Name = "null";
            Surname = "null";
            UserName = "null";
            Password = "null";
            RegistrationDate = Constants.NEVER;
            LastLoginDate = Constants.NEVER;

            Permissions = new List<Permission>();
        }
    }
}
