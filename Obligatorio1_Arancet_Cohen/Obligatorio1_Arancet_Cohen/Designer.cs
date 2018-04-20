﻿using System;

namespace Obligatorio1_Arancet_Cohen
{
    public class Designer : User
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
    }
}