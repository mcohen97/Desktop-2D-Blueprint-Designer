using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entities
{
    public abstract class UserEntity
    {
        public UserEntity() {
        }
     
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public DateTime RegistrationDate { get; set; }

        public DateTime LastLoginDate { get; set; }

        public virtual List<int> Permissions { get; set; }
        

    }
}
