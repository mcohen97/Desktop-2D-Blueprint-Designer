using System;
using System.Collections.Generic;

namespace Obligatorio1ArancetCohen
{
    public class Admin
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime LastLoginDate { get; set; }
        private List<Client> listOfEnabledClients;

        public Admin(string name, string surname, string userName, string password, DateTime registrationDate)
        {
            Name = name;
            Surname = surname;
            UserName = userName;
            Password = password;
            RegistrationDate = registrationDate;
            LastLoginDate = Constants.NEVER;
            listOfEnabledClients = new List<Client>();
        }

        public DateTime updateLastLoginDate()
        {
            DateTime dateOfLogin = DateTime.Now;
            LastLoginDate = dateOfLogin;
            return dateOfLogin;
        }

        public void enableClient(Client client)
        {
            listOfEnabledClients.Add(client);
        }

        public void assignPasswordToClient(Client client, string passwordAssigned)
        {
            client.Password = passwordAssigned;
        }

        public bool isClientEnabled(Client client)
        {
            return listOfEnabledClients.Contains(client);
        }
    }
}