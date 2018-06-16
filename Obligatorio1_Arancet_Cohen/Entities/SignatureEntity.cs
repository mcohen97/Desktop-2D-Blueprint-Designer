using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class SignatureEntity
    {
        public Guid Id { get; set; }

        public UserEntity Signer { get; set; }

        public DateTime SignatureDate { get; set; }

    }
}
