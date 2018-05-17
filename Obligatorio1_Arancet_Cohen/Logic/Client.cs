using System;
using System.Collections.Generic;

namespace Logic.Domain
{
    public class Client : User
    {

        private string phone;
        public string Phone { get {return phone; } set {SetPhone(value); } }

        private string id;
        public string Id { get {return id; } set {SetId(value); } }

        private string address;
        public string Address { get {return address; } set {SetAddress(value); } }

        public Client(string name, string surname, string userName, string password, string phone, string address, string id, DateTime registrationDate)
        {
            Name = name;
            Surname = surname;
            UserName = userName;
            Password = password;
            Phone = phone;
            Address = address;
            Id = id;
            RegistrationDate = registrationDate;
            LastLoginDate = Constants.NEVER;

            Permissions = GeneratePermissions();
        }

        private void SetPhone(string aPhone) {
            if (String.IsNullOrEmpty(aPhone)) {
                throw new ArgumentNullException();
            }
            phone = aPhone;
        }

        private void SetId(string anId) {
            if (String.IsNullOrEmpty(anId)) {
                throw new ArgumentNullException();
            }
            id = anId;
        }

        private void SetAddress(string anAddress) {
            if (String.IsNullOrEmpty(anAddress)) {
                throw new ArgumentNullException();
            }
            address = anAddress;
        }

        private List<Permission> GeneratePermissions() {
            List<Permission> perms=new List<Permission>();
            perms.Add(Permission.READ_BLUEPRINT);
            perms.Add(Permission.HOLD_EXTRA_DATA);
            perms.Add(Permission.FIRST_LOGIN);
            perms.Add(Permission.HAVE_BLUEPRINT);
            perms.Add(Permission.EDIT_OWN_DATA);
            perms.Add(Permission.READ_OWNEDBLUEPRINT);
            return perms;
        }


    }

    
}