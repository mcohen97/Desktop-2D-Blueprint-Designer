using System;

namespace Obligatorio1_Arancet_Cohen
{
    public class Client : Person
    {
      
        public string Phone { get; set; }
        public string Id { get; set; }

        public Client(string name, string surname, string userName, string password, string phone, string id, DateTime registrationDate)
        {
            Name = name;
            Surname = surname;
            UserName = userName;
            Password = password;
            Phone = phone;
            Id = id;
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