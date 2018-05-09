using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public abstract class User:IPermissible,IComparable
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime LastLoginDate { get; set; }
        protected List<Permission> permissions;
        public static readonly User NULL_USER = new NullUser();

        public DateTime updateLastLoginDate()
        {
            DateTime dateOfLogin = DateTime.Now;
            LastLoginDate = dateOfLogin;
            return dateOfLogin;
        }

        public bool hasPermission(Permission permissionAsked)
        {
            bool userHasPermission = false;
            if (permissions.Contains(Permission.ALL_PERMISSIONS) || permissions.Contains(permissionAsked))
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
