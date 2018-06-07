using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ClientEntity: UserEntity
    {
        public ClientEntity() {
        }
        public string Phone { get; set; }

        public string IdCard { get; set; }

        public string Address { get; set; }

    }
}
