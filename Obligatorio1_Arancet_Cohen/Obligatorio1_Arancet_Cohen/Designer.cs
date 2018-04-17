using System;

namespace Obligatorio1_Arancet_Cohen
{
    public class Designer : Person
    {
       
        public Designer(string name, string surname, string userName, string password, DateTime registrationDate)
        {
            Name = name;
            Surname = surname;
            UserName = userName;
            Password = password;
            RegistrationDate = registrationDate;
            LastLoginDate = Constants.NEVER;
        }

        public DateTime updateLastLoginDate()
        {
            DateTime dateOfLogin = DateTime.Now;
            LastLoginDate = dateOfLogin;
            return dateOfLogin;
        }
    }
}