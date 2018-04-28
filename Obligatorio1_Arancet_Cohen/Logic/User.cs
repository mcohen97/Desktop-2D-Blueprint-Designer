using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio1_Arancet_Cohen
{
    public abstract class User:IPermissible,IComparable
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime LastLoginDate { get; set; }
        protected List<Permission> Permissions;
        public static readonly User NULL_USER = new NullUser();

        public DateTime UpdateLastLoginDate()
        {
            DateTime dateOfLogin = DateTime.Now;
            LastLoginDate = dateOfLogin;
            return dateOfLogin;
        }

        public bool HasPermission(Permission permissionAsked)
        {
            bool userHasPermission = false;
            if (Permissions.Contains(Permission.ALL_PERMISSIONS) || Permissions.Contains(permissionAsked))
            {
                userHasPermission = true;
            }
            return userHasPermission;
        }

        public int CompareTo(object obj)
        {
            User userParameter = (User)obj;
            int comparation = UserName.CompareTo(userParameter.UserName);
            return comparation;     
        }

        public override bool Equals(object obj)
        {
            bool equal = false;
            if (obj != null && obj is User)  {
                User userParameter = (User)obj;
                equal = userParameter.UserName.Equals(UserName);
            }
            return equal;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

}
