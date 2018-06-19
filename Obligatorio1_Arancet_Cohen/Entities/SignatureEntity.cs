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

        public string SignerName { get; set; }

        public string SignerSurname { get; set; }

        public string SignerUserName { get; set; }

        public DateTime SignatureDate { get; set; }

        public virtual BlueprintEntity BlueprintSigned { get; set; }

    }
}
