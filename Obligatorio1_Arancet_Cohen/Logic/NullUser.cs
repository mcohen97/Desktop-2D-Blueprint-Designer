﻿using Obligatorio1_Arancet_Cohen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
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

            permissions = new List<Permission>();
        }
    }
}
