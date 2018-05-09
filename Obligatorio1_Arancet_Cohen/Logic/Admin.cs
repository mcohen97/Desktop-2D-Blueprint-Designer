using System;
using System.Collections.Generic;

namespace Logic
{
    public class Admin : User
    {
        private List<User> listOfRegisteredClients;

        public Admin(string name, string surname, string userName, string password, DateTime registrationDate)
        {
            Name = name;
            Surname = surname;
            UserName = userName;
            Password = password;
            RegistrationDate = registrationDate;
            LastLoginDate = Constants.NEVER;
            listOfRegisteredClients = new List<User>();

            permissions = new List<Permission>();
            permissions.Add(Permission.ALL_PERMISSIONS);
        }

        public void registClient(User client)
        {
            listOfRegisteredClients.Add(client);
            //should throw exception if Person is not a Client
        }

        public void assignPasswordToClient(Client client, string passwordAssigned)
        {
            client.Password = passwordAssigned;
        }

        public bool isClientRegistered(Client client)
        {
            return listOfRegisteredClients.Contains(client);
        }

    }
}