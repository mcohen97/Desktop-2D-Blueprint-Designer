using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public abstract class User:IPermissible,IComparable
    {
        private string name;
        public string Name { get {return name; } set { SetName(value); } }
        private string surname;
        public string Surname { get { return surname; } set {SetSurname(value); } }
        private string userName;
        public string UserName { get {return userName; } protected set {SetUserName(value); } }
        private string password;
        public string Password { get { return password; } set { SetPassword(value); } }
        public DateTime RegistrationDate { get; set; }
        public DateTime LastLoginDate { get; set; }
        protected List<Permission> Permissions;
        public static readonly User NULL_USER = new NullUser();

        private void SetName(string aName) {
            if (String.IsNullOrEmpty(aName)) {
                throw new ArgumentNullException();
            }
            name = aName;
        }

        private void SetSurname(string aSurname) {
            if (String.IsNullOrEmpty(aSurname)) {
                throw new ArgumentNullException();
            }
            surname = aSurname;
        }

        private void SetUserName(string aUserName) {
            if (String.IsNullOrEmpty(aUserName)) {
                throw new ArgumentNullException();
            }
            userName = aUserName;
        }

        private void SetPassword(string aPassword) {
            if (String.IsNullOrEmpty(aPassword)) {
                throw new ArgumentNullException();
            }
            password = aPassword;
        }

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

        public void RemovePermission(Permission aPermission) {
            Permissions.Remove(aPermission);
        }

        public override string ToString() {
            return "User name: " + UserName
            +"  " + "Name: " + Name
            +"  " + "Surname: " + Surname;
                       
        }
    }

}
