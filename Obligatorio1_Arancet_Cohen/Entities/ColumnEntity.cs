using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ColumnEntity
    {
        public Guid Id { get; set; }
        public float Width { get; set; }

        public float Length { get; set; }

        public float Height { get; set; }

        public PointEntity Position { get; set; }

        public BlueprintEntity BearerBlueprint { get; set; }
       
    }
}
