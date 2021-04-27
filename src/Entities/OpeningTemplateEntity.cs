using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class OpeningTemplateEntity
    {
        public Guid Id { get; set; }
        public float Height { get; set; }

        public float Length { get; set; }

        public float HeightAboveFloor { get; set; }

        public string Name { get; set; }
              
        public int ComponentType { get; set; }
    }
}
