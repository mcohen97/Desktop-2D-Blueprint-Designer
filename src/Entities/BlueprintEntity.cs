using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class BlueprintEntity
    {
        public Guid Id { get; set; }
        public String Name { get; set; }

        public int Length { get; set; }

        public int Width { get; set; }

        public UserEntity Owner { get; set; }

       // public ICollection<SignatureEntity> Signatures { get; set; }


    }
}
