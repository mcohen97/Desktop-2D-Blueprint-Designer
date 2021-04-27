using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class WallEntity
    {
        public Guid Id { get; set; }
        public WallEntity() {
        }
        public float Height { get; set; }

        public float Width { get; set; }

        public float BeginningX { get; set; }

        public float BeginningY { get; set; }

        public float EndX { get; set; }

        public float EndY { get; set; }

        public BlueprintEntity BearerBlueprint { get; set; }
    }
}
