using System;
using System.Collections.Generic;

namespace Obligatorio1_Arancet_Cohen
{
    public class Admin : Person
    {
        private List<Person> listOfEnabledClients;

        public Admin(string name, string surname, string userName, string password, DateTime registrationDate)
        {
            Name = name;
            Surname = surname;
            UserName = userName;
            Password = password;
            RegistrationDate = registrationDate;
            LastLoginDate = Constants.NEVER;
            listOfEnabledClients = new List<Person>();
        }

        public DateTime updateLastLoginDate()
        {
            DateTime dateOfLogin = DateTime.Now;
            LastLoginDate = dateOfLogin;
            return dateOfLogin;
        }

        public void enableClient(Person client)
        {
            listOfEnabledClients.Add(client);
            //should throw exception if Person its not a Client
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